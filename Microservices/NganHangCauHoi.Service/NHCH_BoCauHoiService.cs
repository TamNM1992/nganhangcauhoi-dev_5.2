

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using NganHangCauHoi.Data.CustomModels;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Generated.Interfaces;
using StackExchange.Redis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_BoCauHoiService 
    {
        //public NHCH_BoCauHoiService(
        //    NganHangCauHoiDataContext dataContext, 
        //    IServiceProvider serviceProvider) : base()
        //{

        //}

        //protected NHCH_BoCauHoiService(
        //    IServiceProvider serviceProvider) 
        //: this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
        //        serviceProvider) {}

        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_BoCauHoi item)
        //    {
        //        item.MarkDirty<NHCH_BoCauHoi>(x => new 
        //        {
        //            item.Code,
        //item.Created,
        //item.CreatedBy,
        //item.Entity,
        //item.EntityKey,
        //item.IdHocPhan,
        //item.IsBuildIn,
        //item.IsDeleted,
        //item.MaHocPhan,
        //item.Modified,
        //item.ModifiedBy,
        //item.ServiceCode,
        //item.SoThuTu,
        //item.Ten,
        //item.TienTo,
        //item.Version,
        //item.IsBuildInAll,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
        public NHCH_BoCauHoiService(IServiceProvider serviceProvider) : base()
        {
        }
        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly INHCH_CauHoiRepos _tbl_NHCH_CauHoiRepos;
        private readonly INHCH_ChuDeRepos _tbl_NHCH_ChuDeRepos;
        private readonly INHCH_CauHoi_CloRepos _tbl_NHCH_CauHoi_CloRepos;
        private readonly INHCH_BoCauHoi_CauHoiRepos _tbl_NHCH_BoCauHoi_CauHoiRepos;
        private readonly INHCH_BoCauHoiRepos _repos;

        private readonly Itbl_HocPhanServiceSdk _tbl_HocPhanServiceSdk;
        private readonly IFileClientService _fileClientService;
        private readonly ITemplateClientService _templateClientService;

        private readonly IUserPrincipalService _userPrincipalService;

        public NHCH_BoCauHoiService(INHCH_BoCauHoiRepos repos,
            IServiceProvider serviceProvider,
            INHCH_ChuDeRepos tbl_NHCH_ChuDeRepos,
            INHCH_CauHoiRepos tbl_NHCH_CauHoiRepos,
            INHCH_CauHoi_CloRepos tbl_NHCH_CauHoi_CloRepos,
            IUserPrincipalService userPrincipalService,
            INHCH_BoCauHoi_CauHoiRepos tbl_NHCH_BoCauHoi_CauHoiRepos,
            Itbl_HocPhanServiceSdk tbl_HocPhanServiceSdk,
            IFileClientService fileClientService,
            ITemplateClientService templateClientService,
            IEntityChangedEventService entityChangedEventService

            )
            : base()
        {
            _repos = repos;
            _tbl_NHCH_ChuDeRepos = tbl_NHCH_ChuDeRepos;
            _tbl_NHCH_CauHoiRepos = tbl_NHCH_CauHoiRepos;
            _tbl_NHCH_CauHoi_CloRepos = tbl_NHCH_CauHoi_CloRepos;
            _userPrincipalService = userPrincipalService;
            _tbl_NHCH_BoCauHoi_CauHoiRepos = tbl_NHCH_BoCauHoi_CauHoiRepos;

            _tbl_HocPhanServiceSdk = tbl_HocPhanServiceSdk;
            _fileClientService = fileClientService;
            _templateClientService = templateClientService;
            _entityChangedEventService = entityChangedEventService;
        }

        public override async Task<IMethodResult<int>> InsertAsync(NHCH_BoCauHoi item)
        {
            var soThuTu = 1;
            var lastItemBoCauHoi = _repos.GetAllLazy()
                                         .Where(x => x.Created.Date == DateTime.UtcNow.Date
                                                     && x.IdHocPhan == item.IdHocPhan)
                                         .OrderByDescending(x => x.SoThuTu)
                                         .FirstOrDefault();

            if (lastItemBoCauHoi != null)
            {
                soThuTu = lastItemBoCauHoi.SoThuTu + 1;
            }
            item.SoThuTu = soThuTu;
            item.Code = GetMaBoCauHoi(item.MaHocPhan, DateTime.UtcNow, soThuTu, item.TienTo);
            item.Ten = $"Bộ câu hỏi {item.Code}";

            var result = await base.InsertAsync(item);
            if (result.Success)
            {
                await UpdateBoCauHoi_CauHoi(item);
            }
            return result;
        }

        private string GetMaBoCauHoi(string maHocPhan, DateTime created, int soThuTu, string tienTo)
        {
            var strIndex = soThuTu < 10 ? $"0{soThuTu}" : $"{soThuTu}";
            var strTime = TimeExtension.GetStringDateTime(created.AddHours(7), "ddMMyyyy");
            return $"{tienTo}_{maHocPhan}_{strTime}_{strIndex}";
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_BoCauHoi item)
        {
            item.Code = GetMaBoCauHoi(item.MaHocPhan, item.Created, item.SoThuTu, item.TienTo);
            item.Ten = $"Bộ câu hỏi {item.Code}";

            item.MarkDirty(nameof(item.Ten));
            item.MarkDirty(nameof(item.IdHocPhan));
            item.MarkDirty(nameof(item.MaHocPhan));
            item.MarkDirty(nameof(item.TienTo));
            item.MarkDirty(nameof(item.Modified));
            item.MarkDirty(nameof(item.ModifiedBy));
            item.MarkDirty(nameof(item.Code));
            item.MarkDirty(nameof(item.IsBuildIn));
            item.MarkDirty(nameof(item.IsBuildInAll));
            item.MarkDirty(nameof(item.ServiceCode));
            item.MarkDirty(nameof(item.Entity));
            item.MarkDirty(nameof(item.EntityKey));
            item.MarkDirty(nameof(item.Version));

            var result = await base.UpdateAsync(item);
            if (result.Success)
            {
                await UpdateBoCauHoi_CauHoi(item);
                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_BOCAUHOI);
            }
            return result;

        }

        private async Task UpdateBoCauHoi_CauHoi(NHCH_BoCauHoi model)
        {
            var lstExists = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy()
                                                                .Where(x => x.IdBoCauHoi == model.Id)
                                                                .ToListAsync();

            if (model.LstCauHoi.Count() > 0)
            {
                var idsCauhoi = model.LstCauHoi.Select(x => x.IdCauHoi).ToList();
                var listCauHoi = _tbl_NHCH_CauHoiRepos.GetAllLazy()
                                                      .Where(x => idsCauhoi.Contains(x.Id))
                                                      .Select(x => new { x.Id, x.Code })
                                                      .ToList();

                var lstInsert = new List<NHCH_BoCauHoi_CauHoi>();
                foreach (var subItem in model.LstCauHoi)
                {
                    var existItem = lstExists.FirstOrDefault(x => x.IdCauHoi == subItem.IdCauHoi);
                    if (existItem == null)
                    {
                        subItem.IdBoCauHoi = model.Id;
                        subItem.MaBoCauHoi = model.Code;
                        subItem.MaCauHoi = listCauHoi.FirstOrDefault(x => x.Id == subItem.IdCauHoi).Code;
                        lstInsert.Add(subItem);
                    }
                }

                if (lstInsert.Count > 0)
                {
                    await _tbl_NHCH_BoCauHoi_CauHoiRepos.InsertBulkAsync(lstInsert);
                }
            }

            var lstDelete = lstExists.Where(x => !model.LstCauHoi.Select(y => y.IdCauHoi).Contains(x.IdCauHoi))
                                     .ToList();
            if (lstDelete.Count > 0)
            {
                await _tbl_NHCH_BoCauHoi_CauHoiRepos.DeleteManyAsync(lstDelete.Select(x => x.Id).ToArray());
            }

        }

        public override async Task<IMethodResult> DeleteAsync(int id)
        {
            var rs = await base.DeleteAsync(id);
            if (rs.Success)
            {
                var lstDelete = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy()
                                                                    .Where(x => x.IdBoCauHoi == id)
                                                                    .Select(x => x.Id)
                                                                    .ToListAsync();

                if (lstDelete.Count > 0)
                {
                    await _tbl_NHCH_BoCauHoi_CauHoiRepos.DeleteManyAsync(lstDelete.ToArray());
                }
            }
            return rs;
        }


        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids)
        {
            var rs = await base.DeleteManyByIdsAsync(ids);
            if (rs.Success)
            {
                var lstDelete = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy()
                                                                    .Where(x => ids.ToList().Contains(x.IdBoCauHoi))
                                                                    .Select(x => x.Id)
                                                                    .ToListAsync();

                if (lstDelete.Count > 0)
                {
                    await _tbl_NHCH_BoCauHoi_CauHoiRepos.DeleteManyAsync(lstDelete.ToArray());
                }
            }
            return rs;
        }

        public override async Task<IMethodResult<NHCH_BoCauHoi>> GetByIdAsync(int id)
        {
            var result = await _repos.GetByIdAsync(id);
            if (result.Success)
            {
                result.Data.tbl_NHCH_BoCauHoi_CauHoi = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy().Where(x => x.IdBoCauHoi == id).ToListAsync();
            }
            return result;
        }

        public async Task<IMethodResult<object>> ExportFileCauHoi(int idBoCauHoi)
        {
            var boCauHoi = await _repos.GetAllLazy()
                                       .FirstOrDefaultAsync(x => x.Id == idBoCauHoi);
            if (boCauHoi == null)
            {
                return MethodResult<object>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin bộ câu hỏi");
            }

            var hocPhanResult = await _tbl_HocPhanServiceSdk.GetByInstanceIdAsync(boCauHoi.IdHocPhan);
            if (!hocPhanResult.Success || hocPhanResult.Data == null)
            {
                return MethodResult<object>.ResultWithError(Validation.ERR_NOT_FOUND, message: "Không tìm thấy thông tin học phần");
            }

            var lstIdCauHoi = await _tbl_NHCH_BoCauHoi_CauHoiRepos.GetAllLazy()
                                                                  .Where(x => x.IdBoCauHoi == idBoCauHoi)
                                                                  .Select(x => x.IdCauHoi)
                                                                  .ToListAsync();
            if (lstIdCauHoi.Count == 0)
            {
                return MethodResult<object>.ResultWithError(Validation.ERR_NOT_FOUND, message: $"Chưa có câu hỏi nào trong bộ {boCauHoi.Code}");
            }

            var lstCauHoi = await _tbl_NHCH_CauHoiRepos.GetAllLazy()
                                                       .Where(x => lstIdCauHoi.Contains(x.Id))
                                                       .ToListAsync();

            var lstCauHoi_CLO = await _tbl_NHCH_CauHoi_CloRepos.GetAllLazy()
                                                               .Where(x => lstIdCauHoi.Contains(x.IdCauHoi))
                                                               .ToListAsync();

            var lstIdChuDe = lstCauHoi.Select(x => x.IdChuDe).ToList();
            var lstChuDe = await _tbl_NHCH_ChuDeRepos.GetAllLazy()
                                                     .Where(x => lstIdChuDe.Contains(x.Id))
                                                     .ToListAsync();

            var lstExport = new List<object>();
            foreach (var itemCauHoi in lstCauHoi)
            {
                var maCLOStr = string.Join(",", lstCauHoi_CLO.Where(x => x.IdCauHoi == itemCauHoi.Id)
                                                             .Select(x => x.MaClo)
                                                             .ToList());

                var sendFileObject = new ServiceFileObjectModel()
                {
                    Service = ServiceConstant.SERVICE_NAME,
                    Entity = ServiceConstant.ENTITY_TBL_NHCH_CAUHOI,
                    EntityInstanceId = itemCauHoi.InstanceId
                };

                var fileBinaryResult = await _fileClientService.GetSingleServiceFileBinary(sendFileObject);
                if (fileBinaryResult.Success && fileBinaryResult.Data != null)
                {
                    var noiDung = ConvertHelper.ByteArrayToBase64(fileBinaryResult.Data.Content);
                    if (string.IsNullOrWhiteSpace(noiDung))
                    {
                        return MethodResult<object>.ResultWithError(Validation.ERR_NOT_FOUND, message: $"Nội dung câu hỏi {itemCauHoi.Code} không tồn tại");
                    }

                    var chuDe = lstChuDe.FirstOrDefault(x => x.Id == itemCauHoi.IdChuDe);
                    if (chuDe != null)
                    {
                        lstExport.Add(new
                        {
                            maCauHoi = itemCauHoi.Code,
                            tinChi = chuDe.TinChi,
                            mucDo = chuDe.MucDo,
                            maChuDe = chuDe.Ten,
                            chuanDauRa = maCLOStr,
                            noiDung = noiDung,
                        });
                    }
                }
            }

            dynamic data = new JObject();
            data.tenHocPhan = hocPhanResult.Data.Ten;
            data.maBoCauHoi = boCauHoi.Code;
            data.danhSachCauHoi = JToken.FromObject(lstExport);

            return MethodResult<object>.ResultWithData(data);
        }
    }
}