

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
using NganHangCauHoi.Data.CustomModels;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Interfaces;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_MaTranDeThiService 
    {
        public NHCH_MaTranDeThiService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_MaTranDeThiService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}


        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly INHCH_MaTranDeThi_ChiTietRepos _tbl_NHCH_MaTranDeThi_ChiTietRepos;
        private readonly ITemplateClientService _templateClientService;
        private readonly INHCH_MaTranDeThiRepos _repos;

        public NHCH_MaTranDeThiService(
            INHCH_MaTranDeThiRepos repos,
            IServiceProvider serviceProvider,
            IEntityChangedEventService entityChangedEventService,
            IUserPrincipalService userPrincipalService,
            INHCH_MaTranDeThi_ChiTietRepos tbl_NHCH_MaTranDeThi_ChiTietRepos,
            ITemplateClientService templateClientService
            )
            : base(repos, serviceProvider)
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _userPrincipalService = userPrincipalService;
            _tbl_NHCH_MaTranDeThi_ChiTietRepos = tbl_NHCH_MaTranDeThi_ChiTietRepos;
            _templateClientService = templateClientService;
        }

        public override async Task<IMethodResult<NHCH_MaTranDeThi>> GetByIdAsync(int id)
        {
            var rs = await base.GetByIdAsync(id);
            if (rs.Success)
            {
                rs.Data.MaTran_ChiTiets = _tbl_NHCH_MaTranDeThi_ChiTietRepos.GetAllLazy()
                                                                            .Where(x => x.IdMaTranDeThi == id)
                                                                            .OrderBy(x => x.TinChi)
                                                                            .ThenBy(x => x.IdMucDo)
                                                                            .ThenBy(x => x.IdChuDe)
                                                                            .ToList();
            }
            return rs;
        }

        public override async Task<IMethodResult<int>> InsertAsync(NHCH_MaTranDeThi item)
        {
            int index = 0;
            var itemLatestMaTranDe = _repos.GetAllLazy()
                                         .Where(x => x.IdHocPhan == item.IdHocPhan)
                                         .OrderByDescending(x => x.Created.Date == DateTime.UtcNow.Date)
                                         .OrderByDescending(x => x.SoThuTu)
                                         .FirstOrDefault();

            if (itemLatestMaTranDe == null)
            {
                item.SoThuTu = index + 1;
            }
            else
            {
                item.SoThuTu = itemLatestMaTranDe.SoThuTu + 1;
            }
            item.Code = GetMaCauHoi(DateTime.UtcNow.Date, item.MaHocPhan, item.SoThuTu, item.TienTo);
            item.Ten = $"Ma trận {item.Code}";
            item.TongCauHoi = item.MaTran_ChiTiets.Count;
            item.TongDiem = item.MaTran_ChiTiets.Select(x => x.Diem.Value).Sum();

            var result = await base.InsertAsync(item);
            if (result.Success)
            {
                await UpdateMaTranChiTiet(item);
            }

            return result;
        }

        private string GetMaCauHoi(DateTime created, string maHocPhan, int index, string tienTo)
        {
            var strIndex = index < 10 ? $"0{index}" : $"{index}";

            // convert sang time VN
            created = created.AddHours(7);
            var dateStr = TimeExtension.GetStringDateTime(created, "ddMMyyyy");
            return $"{tienTo}_{maHocPhan}_{dateStr}_{strIndex}";
        }

        //public override async Task<IMethodResult> UpdateAsync(NHCH_MaTranDeThi item)
        //{
        //    item.Code = GetMaCauHoi(item.Created, item.MaHocPhan, item.SoThuTu, item.TienTo);
        //    item.Ten = $"Ma trận {item.Code}";

        //    item.MarkDirty(nameof(item.Ten));
        //    item.MarkDirty(nameof(item.IdHocPhan));
        //    item.MarkDirty(nameof(item.MaHocPhan));
        //    item.MarkDirty(nameof(item.SoThuTu));
        //    item.MarkDirty(nameof(item.TienTo));
        //    item.MarkDirty(nameof(item.Modified));
        //    item.MarkDirty(nameof(item.ModifiedBy));
        //    item.MarkDirty(nameof(item.Code));
        //    item.MarkDirty(nameof(item.IsBuildIn));
        //    item.MarkDirty(nameof(item.IsBuildInAll));
        //    item.MarkDirty(nameof(item.ServiceCode));
        //    item.MarkDirty(nameof(item.Entity));
        //    item.MarkDirty(nameof(item.EntityKey));
        //    item.MarkDirty(nameof(item.Version));

        //    var result = await base.UpdateAsync(item);
        //    if (result.Success)
        //    {
        //        await UpdateMaTranChiTiet(item);
        //        _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_MATRANDETHI);
        //    }
        //    return result;
        //}

        private async Task UpdateMaTranChiTiet(NHCH_MaTranDeThi model)
        {
            var lstExistsItem = await _tbl_NHCH_MaTranDeThi_ChiTietRepos.GetAllLazy()
                                                                  .Where(x => x.IdMaTranDeThi == model.Id)
                                                                  .ToListAsync();

            var lstInsert = new List<NHCH_MaTranDeThi_ChiTiet>();
            var lstUpdate = new List<NHCH_MaTranDeThi_ChiTiet>();

            model.MaTran_ChiTiets.ForEach(item =>
            {
                var itemExist = lstExistsItem.FirstOrDefault(x => x.TinChi == item.TinChi
                                                                  && x.IdMucDo == item.IdMucDo
                                                                  && x.IdChuDe == item.IdChuDe);
                if (itemExist == null)
                {
                    item.IdMaTranDeThi = model.Id;
                    lstInsert.Add(item);
                }
                else
                {
                    itemExist.SoCauHoi = item.SoCauHoi;
                    itemExist.Diem = item.Diem;
                    lstUpdate.Add(itemExist);
                }
            });

            if (lstInsert.Count > 0)
            {
                await _tbl_NHCH_MaTranDeThi_ChiTietRepos.InsertBulkAsync(lstInsert);
            }

            if (lstUpdate.Count > 0)
            {
                await _tbl_NHCH_MaTranDeThi_ChiTietRepos.UpdateBulkAsync(lstUpdate);
            }

            var lstDelete = lstExistsItem.Where(x => !lstUpdate.Select(y => y.Id).Contains(x.Id)).ToList();
            if (lstDelete.Count > 0)
            {
                await _tbl_NHCH_MaTranDeThi_ChiTietRepos.DeleteManyAsync(lstDelete.Select(x => x.Id).ToArray());
            }
        }

        public override async Task<IMethodResult> DeleteAsync(int id)
        {
            var result = await base.DeleteAsync(id);
            if (result.Success)
            {
                var subList = await _tbl_NHCH_MaTranDeThi_ChiTietRepos.GetAllLazy()
                                                .Where(c => c.IdMaTranDeThi == id)
                                                .ToListAsync();
                if (subList.Any())
                {
                    await _tbl_NHCH_MaTranDeThi_ChiTietRepos.DeleteManyAsync(subList.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids)
        {
            var result = await base.DeleteManyByIdsAsync(ids);
            if (result.Success)
            {
                var listDelete = await _tbl_NHCH_MaTranDeThi_ChiTietRepos.GetAllLazy()
                    .Where(x => ids.Contains(x.IdMaTranDeThi)).ToListAsync();
                if (listDelete != null && listDelete.Count > 0)
                {
                    await _tbl_NHCH_MaTranDeThi_ChiTietRepos.DeleteManyAsync(listDelete.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public async Task<IMethodResult<List<NHCH_MaTranDeThi>>> GetPagedDeep(GridInfo gridInfo)
        {
            var query = _repos.GetAllLazy().Select(item => new NHCH_MaTranDeThi
            {
                Id = item.Id,
                Ten = item.Ten,
                IdHocPhan = item.IdHocPhan,
                MaHocPhan = item.MaHocPhan,
                Created = item.Created,
                CreatedBy = item.CreatedBy,
                Modified = item.Modified,
                ModifiedBy = item.ModifiedBy,
                IsDeleted = item.IsDeleted,
                Code = item.Code,
                InstanceId = item.InstanceId,
                IsBuildIn = item.IsBuildIn,
                IsBuildInAll = item.IsBuildInAll,
                ServiceCode = item.ServiceCode,
                Entity = item.Entity,
                EntityKey = item.EntityKey,
                Version = item.Version,
                TongCauHoi = 0,
                TongDiem = 0,
                NHCH_MaTranDeThi_ChiTiets = item.NHCH_MaTranDeThi_ChiTiets.ToList()
            });

            var result = await query.GetPaged<NHCH_MaTranDeThi, NHCH_MaTranDeThi_ChiTiet>(gridInfo);

            if (result.Total > 0)
            {
                foreach (var item in result.Data)
                {
                    if (item.tbl_NHCH_MaTranDeThi_ChiTiet.Any())
                    {
                        item.TongCauHoi = item.tbl_NHCH_MaTranDeThi_ChiTiet.Sum(x => x.SoCauHoi == null ? 0 : x.SoCauHoi.Value);
                        item.TongDiem = item.tbl_NHCH_MaTranDeThi_ChiTiet.Sum(x => x.Diem == null ? 0 : x.Diem.Value * x.SoCauHoi.Value);
                    }
                }
            }
            return MethodResult<List<NHCH_MaTranDeThi>>.ResultWithData(result.Data, "", result.Total);
        }
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_MaTranDeThi item)
        {
            item.MarkDirty<NHCH_MaTranDeThi>(x => new
            {
                item.Code,
                item.Created,
                item.CreatedBy,
                item.Entity,
                item.EntityKey,
                item.IdHocPhan,
                item.IsBuildIn,
                item.IsBuildInAll,
                item.IsDeleted,
                item.MaHocPhan,
                item.Modified,
                item.ModifiedBy,
                item.ServiceCode,
                item.SoThuTu,
                item.Ten,
                item.TienTo,
                item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}