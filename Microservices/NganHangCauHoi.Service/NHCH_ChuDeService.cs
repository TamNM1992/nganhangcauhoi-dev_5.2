

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Generated.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_ChuDeService 
    {
        public NHCH_ChuDeService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_ChuDeService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}

        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly INHCH_ChuDe_MucTieuRepos _tbl_NHCH_ChuDe_MucTieuRepos;
        private readonly Itbl_HocPhanServiceSdk _tbl_HocPhanServiceSdk;
        private readonly Itbl_HocPhan_MucTieu_ChuanDauRaServiceSdk _tbl_HocPhan_MucTieu_ChuanDauRaServiceSdk;
        private readonly INHCH_ChuDeRepos _repos;


        public NHCH_ChuDeService(INHCH_ChuDeRepos repos,
                                        IServiceProvider serviceProvider,
                                        IEntityChangedEventService entityChangedEventService,
                                        INHCH_ChuDe_MucTieuRepos tbl_NHCH_ChuDe_MucTieuRepos,
                                        IUserPrincipalService userPrincipalService,
                                        IHostingEnvironment hostingEnvironment,
                                        Itbl_HocPhanServiceSdk tbl_HocPhanServiceSdk,
                                        Itbl_HocPhan_MucTieu_ChuanDauRaServiceSdk tbl_HocPhan_MucTieu_ChuanDauRaServiceSdk
            )
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _tbl_NHCH_ChuDe_MucTieuRepos = tbl_NHCH_ChuDe_MucTieuRepos;
            _userPrincipalService = userPrincipalService;
            _hostingEnvironment = hostingEnvironment;
            _tbl_HocPhanServiceSdk = tbl_HocPhanServiceSdk;
            _tbl_HocPhan_MucTieu_ChuanDauRaServiceSdk = tbl_HocPhan_MucTieu_ChuanDauRaServiceSdk;
        }

        public async Task<IMethodResult<object>> Find(GridInfo gridInfo)
        {
            var result = await _repos.GetAllLazy()
                .Include(x => x.tbl_NHCH_ChuDe_MucTieu)
                .Select(x => x).GetPaged(gridInfo);
            return new MethodResult<object>()
            {
                Data = result.Data,
                TotalRecord = result.Total,
                Success = true
            };
        }

        public async Task<IMethodResult<byte[]>> GetFileMauImport()
        {
            //var physicalPath = Path.Combine(_hostingEnvironment.WebRootPath, "FileMauImport-ChuDe.xlsx");
            //var content = new FileStream(physicalPath, FileMode.Open, FileAccess.Read, FileShare.Read);

            //using var xlPackage = new ExcelPackage(content);
            //var worksheet = xlPackage.Workbook.Worksheets[1];
            //if (worksheet == null)
            //{
            //    throw new Exception();
            //}

            //#region Học phần
            //var startRowHead = 4;
            //var startRow = 5;
            //var endRow = 20;
            //var col = 2;
            ////Học phần
            //var grid = new GridInfo()
            //{
            //    PageInfo = new PageInfo() { Page = 1, PageSize = 10000 },
            //    Filters = new List<Filter>(),
            //    Sorts = new List<Sort>(),
            //    Fields = "id,code,ten,version"
            //};


            //var listHocPhan = (await _tbl_HocPhanServiceSdk.GetPaged(grid)).Data.ToList();
            //var list = listHocPhan.Select(x => new { x.Id, x.Ten }).Distinct().ToList();
            //endRow = startRow + list.Count;
            ////tieu de
            //worksheet.Cells[startRowHead, col].Value = "Tên";
            //foreach (var item in list)
            //{
            //    worksheet.Cells[startRow, col].Value = item.Id + ". " + item.Ten;
            //    startRow++;
            //}

            //using (ExcelRange Rng = worksheet.Cells[startRowHead, col, endRow - 1, col])
            //{
            //    ExcelTableCollection tblcollection = worksheet.Tables;
            //    ExcelTable table = tblcollection.Add(Rng, "DmHocPhan");
            //    if (list.Any())
            //    {
            //        table.ShowFilter = true;
            //    }
            //    table.TableStyle = TableStyles.Light10;

            //}

            //#endregion

            //#region Mục tiêu
            //startRowHead = 4;
            //startRow = 5;
            //endRow = 20;
            //col = 4;
            ////hinh thuc tuyen sinh
            //var list1 = _tbl_NHCH_MucTieuRepos.GetAllLazy().ToList();
            //endRow = startRow + list1.Count;
            ////tieu de
            //worksheet.Cells[startRowHead, col].Value = "Tên";
            //foreach (var item in list1)
            //{
            //    worksheet.Cells[startRow, col].Value = item.Code + ". " + item.Ten;
            //    startRow++;
            //}

            //using (ExcelRange Rng = worksheet.Cells[startRowHead, col, endRow - 1, col])
            //{
            //    ExcelTableCollection tblcollection = worksheet.Tables;
            //    ExcelTable table = tblcollection.Add(Rng, "DmMucTieu");
            //    if (list1.Any())
            //    {
            //        table.ShowFilter = true;
            //    }
            //    table.TableStyle = TableStyles.Light10;
            //}
            //#endregion

            //return new MethodResult<byte[]>()
            //{
            //    Data = xlPackage.GetAsByteArray(),
            //    Success = true
            //};
            return null;
        }

        public async Task<IMethodResult<object>> ImportExcel(List<NHCH_ChuDe> listChuDe)
        {
            //var listMa = listChuDe.Select(x => x.Code).ToList();
            //if (_repos.GetAllLazy().Any(x => listMa.Contains(x.Code)))
            //{
            //    return MethodResult<object>.ResultWithError("", 200, "Mã đã tồn tại trong cơ sở dữ liệu");
            //}
            //if (listChuDe.Any(x => string.IsNullOrEmpty(x.Ten)))
            //{
            //    return MethodResult<object>.ResultWithError("", 200, "Tên chủ đề không được để trống");
            //}
            //var listMucTieu = await _tbl_NHCH_MucTieuRepos.GetAllLazy().ToListAsync();
            ////Học phần
            //var listHocPhan = (await _tbl_HocPhanServiceSdk.GetAllAsync()).Data.ToList();

            //foreach (var item in listChuDe)
            //{
            //    var hocphan = listHocPhan.FirstOrDefault(x => x.Id == item.IdHP);
            //    var listMaMucTieu = item.ListMucTieu.Split(";").ToList();
            //    var listItemMucTieu = listMucTieu.Where(x => listMaMucTieu.Contains(x.Code)).ToList();

            //    item.tbl_NHCH_ChuDe_MucTieu = new List<tbl_NHCH_ChuDe_MucTieu>();
            //    foreach (var a in listItemMucTieu)
            //    {
            //        var itemClo = new tbl_NHCH_ChuDe_MucTieu()
            //        {
            //            IdChuDe = item.Id,
            //            InstanceIdClo = a.InstanceId,
            //            MaClo = a.Code,
            //            CreatedBy = _userPrincipalService.UserId.ToString(),
            //            ModifiedBy = _userPrincipalService.UserId.ToString(),
            //            Created = DateTime.UtcNow,
            //            Modified = DateTime.UtcNow,
            //            InstanceId = Guid.NewGuid(),
            //        };
            //        item.tbl_NHCH_ChuDe_MucTieu.Add(itemClo);
            //    }
            //    if (hocphan != null)
            //    {
            //        item.IdHocPhan = hocphan.InstanceId;
            //        item.MaHocPhan = hocphan.Code;
            //    }
            //    item.CreatedBy = _userPrincipalService.UserId.ToString();
            //    item.ModifiedBy = _userPrincipalService.UserId.ToString();
            //    item.Created = DateTime.UtcNow;
            //    item.Modified = DateTime.UtcNow;
            //    item.InstanceId = Guid.NewGuid();

            //    await _repos.InsertAsync(item);
            //}

            //return new MethodResult<object>()
            //{
            //    Success = true,
            //    Data = listChuDe,
            //    Message = "Thành công"
            //};
            return null;
        }


        #region Refactor và làm lại ngày 21/07/2021

        public override async Task<IMethodResult<int>> InsertAsync(NHCH_ChuDe item)
        {
            if (await _repos.GetAllLazy().AnyAsync(x => x.IdHocPhan == item.IdHocPhan
                                                        && x.TinChi == item.TinChi
                                                        && x.MucDo == item.MucDo
                                                        && x.ThuTu == item.ThuTu))
            {
                return MethodResult<int>.ResultWithError(Validation.ERR_BUSINESS, message: $"Chủ đề số {item.ThuTu} thuộc mức độ {item.MucDo}, tín chỉ {item.TinChi} đã tồn tại");
            }

            item.GenerateTen();
            var result = await base.InsertAsync(item);
            if (result.Success)
            {
                await UpdateNHCHChuDe_Clo(item);
            }
            return result;
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_ChuDe item)
        {
            if (await _repos.GetAllLazy().AnyAsync(x => x.IdHocPhan == item.IdHocPhan
                                            && x.TinChi == item.TinChi
                                            && x.MucDo == item.MucDo
                                            && x.ThuTu == item.ThuTu
                                            && x.Id != item.Id))
            {
                return MethodResult.ResultWithError(Validation.ERR_BUSINESS, message: $"Chủ đề số {item.ThuTu} thuộc mức độ {item.MucDo}, tín chỉ {item.TinChi} đã tồn tại");
            }

            item.GenerateTen();
            item.MarkDirty(nameof(item.Ten));
            item.MarkDirty(nameof(item.MoTa));
            item.MarkDirty(nameof(item.ThuTu));
            item.MarkDirty(nameof(item.IdHocPhan));
            item.MarkDirty(nameof(item.MaHocPhan));
            item.MarkDirty(nameof(item.TinChi));
            item.MarkDirty(nameof(item.MucDo));
            item.MarkDirty(nameof(item.InstanceIdMucDo));
            item.MarkDirty(nameof(item.Modified));
            item.MarkDirty(nameof(item.ModifiedBy));
            item.MarkDirty(nameof(item.Code));
            //item.MarkDirty(nameof(item.IsBuildIn));
            //item.MarkDirty(nameof(item.IsBuildInAll));
            //item.MarkDirty(nameof(item.ServiceCode));
            //item.MarkDirty(nameof(item.Entity));
            //item.MarkDirty(nameof(item.EntityKey));
            //item.MarkDirty(nameof(item.Version));

            var result = await base.UpdateAsync(item);
            if (result.Success)
            {
                await UpdateNHCHChuDe_Clo(item);
                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_CHUDE);
            }
            return result;
        }

        private async Task UpdateNHCHChuDe_Clo(NHCH_ChuDe model)
        {
            var lstExistsItem = await _tbl_NHCH_ChuDe_MucTieuRepos.GetAllLazy()
                                                            .Where(x => x.IdChuDe == model.Id)
                                                            .ToListAsync();

            if (model.LstInstanceIdClo == null || model.LstInstanceIdClo.Count == 0)
            {
                await _tbl_NHCH_ChuDe_MucTieuRepos.DeleteManyAsync(lstExistsItem.Select(x => x.Id).ToArray());
                return;
            }

            var hpCLoRs = await _tbl_HocPhan_MucTieu_ChuanDauRaServiceSdk.GetByInstanceIdsAsync(model.LstInstanceIdClo.ToArray());
            if (!hpCLoRs.Success)
            {
                return;
            }

            var lstInsert = new List<NHCH_ChuDe_MucTieu>();
            var lstUpdate = new List<NHCH_ChuDe_MucTieu>();

            model.LstInstanceIdClo.ForEach(item =>
            {
                var itemClo = hpCLoRs.Data.FirstOrDefault(x => x.InstanceId == item);
                if (itemClo == null)
                    return;

                var itemExists = lstExistsItem.FirstOrDefault(x => x.InstanceIdClo == item);
                if (itemExists != null)
                {
                    lstUpdate.Add(itemExists);
                }
                else
                {
                    lstInsert.Add(new NHCH_ChuDe_MucTieu()
                    {
                        IdChuDe = model.Id,
                        InstanceIdClo = itemClo.InstanceId,
                        MaClo = itemClo.MaHienThi
                    });
                }
            });

            if (lstInsert.Count > 0)
            {
                await _tbl_NHCH_ChuDe_MucTieuRepos.InsertBulkAsync(lstInsert);
            }

            var lstDelete = lstExistsItem.Where(x => !lstUpdate.Select(y => y.Id).Contains(x.Id)).ToList();
            if (lstDelete.Count > 0)
            {
                await _tbl_NHCH_ChuDe_MucTieuRepos.DeleteManyAsync(lstDelete.Select(x => x.Id).ToArray());
            }
        }

        public override async Task<IMethodResult<NHCH_ChuDe>> GetByIdAsync(int id)
        {
            var result = await base.GetByIdAsync(id);
            if (result.Success)
            {
                result.Data.LstInstanceIdClo = await _tbl_NHCH_ChuDe_MucTieuRepos.GetAllLazy()
                                                                           .Where(x => x.IdChuDe == id)
                                                                           .Select(x => x.InstanceIdClo)
                                                                           .ToListAsync();
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteAsync(int id)
        {
            var result = await base.DeleteAsync(id);
            if (result.Success)
            {
                var subList = await _tbl_NHCH_ChuDe_MucTieuRepos
                                                .GetAllLazy()
                                                .Where(c => c.IdChuDe == id)
                                                .ToListAsync();
                if (subList.Count > 0)
                {
                    await _tbl_NHCH_ChuDe_MucTieuRepos.DeleteManyAsync(subList.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids)
        {
            var result = await base.DeleteManyByIdsAsync(ids);
            if (result.Success)
            {
                var listDelete = await _tbl_NHCH_ChuDe_MucTieuRepos.GetAllLazy()
                                                                   .Where(x => ids.Contains(x.IdChuDe))
                                                                   .ToListAsync();
                if (listDelete.Count > 0)
                {
                    await _tbl_NHCH_ChuDe_MucTieuRepos.DeleteManyAsync(listDelete.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public async Task<IMethodResult<List<NHCH_ChuDe>>> GetPageDeep(GridInfo gridInfo)
        {
            var rs = await base.GetPaged(gridInfo);
            if (rs.Success)
            {
                var lstIdChuDe = rs.Data.Select(x => x.Id).ToList();
                var lstChuDeClo = await _tbl_NHCH_ChuDe_MucTieuRepos.GetAllLazy()
                                                                    .Where(x => lstIdChuDe.Contains(x.IdChuDe))
                                                                    .ToListAsync();

                foreach (var itemChuDe in rs.Data)
                {
                    itemChuDe.tbl_NHCH_ChuDe_MucTieu = lstChuDeClo.Where(x => x.IdChuDe == itemChuDe.Id).ToList();
                    itemChuDe.LstInstanceIdClo = itemChuDe.tbl_NHCH_ChuDe_MucTieu.Select(x => x.InstanceIdClo).ToList();
                    itemChuDe.MaCloStr = string.Join(", ", itemChuDe.tbl_NHCH_ChuDe_MucTieu.Select(x => x.MaClo).ToList());
                }
            }
            return rs;
        }

        #endregion
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_ChuDe item)
        //    {
        //        item.MarkDirty<NHCH_ChuDe>(x => new 
        //        {
        //            item.Code,
        //item.Created,
        //item.CreatedBy,
        //item.Entity,
        //item.EntityKey,
        //item.IdHocPhan,
        //item.IdMucDo,
        //item.IsBuildIn,
        //item.IsBuildInAll,
        //item.IsDeleted,
        //item.MaHocPhan,
        //item.Modified,
        //item.ModifiedBy,
        //item.MoTa,
        //item.MucDo,
        //item.ServiceCode,
        //item.Ten,
        //item.ThuTu,
        //item.TinChi,
        //item.Version,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
    }
}