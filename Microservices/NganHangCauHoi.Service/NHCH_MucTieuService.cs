

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
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_MucTieuService 
    {
        public NHCH_MucTieuService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_MucTieuService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}


        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly INHCH_MucTieu_CloRepos _tbl_NHCH_MucTieu_CloRepos;
        private readonly INHCH_CloRepos _tbl_NHCH_CloRepos;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly INHCH_MucTieuRepos _repos;


        public NHCH_MucTieuService(INHCH_MucTieuRepos repos,
            IServiceProvider serviceProvider,
            IEntityChangedEventService entityChangedEventService,
            INHCH_MucTieu_CloRepos tbl_NHCH_MucTieu_CloRepos,
            INHCH_CloRepos tbl_NHCH_CloRepos,
            IUserPrincipalService userPrincipalService
            )
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _tbl_NHCH_MucTieu_CloRepos = tbl_NHCH_MucTieu_CloRepos;
            _tbl_NHCH_CloRepos = tbl_NHCH_CloRepos;
            _userPrincipalService = userPrincipalService;
        }

        public override async Task<IMethodResult<int>> InsertAsync(NHCH_MucTieu item)
        {
            if (item.NHCH_MucTieu_Clos != null && item.NHCH_MucTieu_Clos.Any())
            {
                foreach (var subItem in item.NHCH_MucTieu_Clos)
                {
                    subItem.InstanceId = Guid.NewGuid();
                    subItem.Created = DateTime.UtcNow;
                    subItem.CreatedBy = _userPrincipalService.UserId.ToString();
                    subItem.Modified = DateTime.UtcNow;
                    subItem.ModifiedBy = _userPrincipalService.UserId.ToString();
                }
            }

            var result = await base.InsertAsync(item);
            return result;
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_MucTieu item)
        {
            item.MarkDirty(nameof(item.Ten));
            item.MarkDirty(nameof(item.MoTa));
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
                // Detach dữ liệu của các collection con & item cha
                if (item.NHCH_MucTieu_Clos.Any())
                {
                    foreach (var child in item.NHCH_MucTieu_Clos)
                    {
                        _tbl_NHCH_MucTieu_CloRepos.DetachModel(child);
                    }
                }
                _repos.DetachModel(item);

                // Get dữ liệu collection con
                List<NHCH_MucTieu_Clo> listUpdate = await _tbl_NHCH_MucTieu_CloRepos.GetAllLazy()
                    .Where(x => x.IdMucTieu == item.Id).AsNoTracking().ToListAsync();

                if (item.NHCH_MucTieu_Clos.Any())
                {
                    foreach (var chiTiet in item.NHCH_MucTieu_Clos)
                    {
                        var itemUpdate = listUpdate.FirstOrDefault(x => x.Id == chiTiet.Id);
                        if (itemUpdate != null)
                        {
                            itemUpdate.IdClo = chiTiet.IdClo;
                            itemUpdate.MaClo = chiTiet.MaClo;
                            if (itemUpdate.CreatedBy == null)
                            {
                                itemUpdate.InstanceId = Guid.NewGuid();
                                itemUpdate.Created = DateTime.UtcNow;
                                itemUpdate.CreatedBy = _userPrincipalService.UserId.ToString();
                            }
                            itemUpdate.Modified = DateTime.UtcNow;
                            itemUpdate.ModifiedBy = _userPrincipalService.UserId.ToString();
                        }
                    }
                }

                List<NHCH_MucTieu_Clo> listDelete = listUpdate.Where(x => !item.NHCH_MucTieu_Clos.Any(y => y.Id == x.Id)).ToList();

                // Cập nhật dữ liệu vào DB
                if (listUpdate.Count > 0)
                {
                    foreach (var updateItem in listUpdate)
                    {
                        await _tbl_NHCH_MucTieu_CloRepos.UpdateEntireModel(updateItem);
                    }
                }

                if (listDelete.Count > 0)
                {
                    await _tbl_NHCH_MucTieu_CloRepos.DeleteManyAsync(listDelete.Select(x => x.Id).ToArray());
                }

                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_MUCTIEU);
            }
            return result;
        }

        public override async Task<IMethodResult<NHCH_MucTieu>> GetByIdAsync(int id)
        {
            var result = await base.GetByIdAsync(id);
            if (result.Success)
            {
                result.Data.tbl_NHCH_MucTieu_Clo = await _tbl_NHCH_MucTieu_CloRepos.GetAllLazy().Where(x => x.IdMucTieu == id).ToListAsync();
            }
            return result;
        }

        public async Task<IMethodResult<object>> Find(GridInfo gridInfo)
        {
            var result = await _repos.GetAllLazy()
                .Include(x => x.NHCH_MucTieu_Clos)
                .Select(x => x).GetPaged(gridInfo);
            return new MethodResult<object>()
            {
                Data = result.Data,
                TotalRecord = result.Total,
                Success = true
            };
        }

        public override async Task<IMethodResult> DeleteAsync(int id)
        {
            var result = await base.DeleteAsync(id);
            if (result.Success)
            {
                var subList = await _tbl_NHCH_MucTieu_CloRepos.GetAllLazy()
                                                .Where(c => c.IdMucTieu == id)
                                                .ToListAsync();
                if (subList.Any())
                {
                    await _tbl_NHCH_MucTieu_CloRepos.DeleteManyAsync(subList.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }

        public override async Task<IMethodResult> DeleteManyByIdsAsync(int[] ids)
        {
            var result = await base.DeleteManyByIdsAsync(ids);
            if (result.Success)
            {
                var listDelete = await _tbl_NHCH_MucTieu_CloRepos.GetAllLazy()
                    .Where(x => x.IdMucTieu != null && ids.Contains(x.IdMucTieu.Value)).ToListAsync();
                if (listDelete != null && listDelete.Count > 0)
                {
                    await _tbl_NHCH_MucTieu_CloRepos.DeleteManyAsync(listDelete.Select(x => x.Id).ToArray());
                }
            }
            return result;
        }


        public async Task<IMethodResult<byte[]>> GetFileMauImport()
        {

            using (var xlPackage = new ExcelPackage())
            {
                xlPackage.Workbook.Worksheets.Add("Danh Mục");
                var worksheet = xlPackage.Workbook.Worksheets[0];
                worksheet.Cells[1, 1].Value = "Mã mục tiêu";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Column(1).Width = 15;
                worksheet.Cells[1, 1].Style.Font.Size = 14;
                worksheet.Cells[1, 2].Value = "Tên mục tiêu";
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Font.Size = 14;
                worksheet.Column(2).Width = 25;
                worksheet.Cells[1, 3].Value = "Danh sách clo";
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Font.Size = 14;
                worksheet.Column(3).Width = 50;
                worksheet.Cells[1, 4].Value = "Mô tả";
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Font.Size = 14;
                worksheet.Column(4).Width = 50;

                ExcelRange Rng = worksheet.Cells[1, 1, 1, 4];
                Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                return new MethodResult<byte[]>()
                {
                    Data = xlPackage.GetAsByteArray(),
                    Success = true
                };

            }

        }

        public async Task<IMethodResult<object>> ImportExcel(List<NHCH_MucTieu> listMucTieu)
        {
            var listMa = listMucTieu.Select(x => x.Code).ToList();
            if (_repos.GetAllLazy().Any(x => listMa.Contains(x.Code)))
            {
                return MethodResult<object>.ResultWithError("", 200, "Mã đã tồn tại trong cơ sở dữ liệu");
            }
            if (listMucTieu.Any(x => string.IsNullOrEmpty(x.Ten)))
            {
                return MethodResult<object>.ResultWithError("", 200, "Tên mục tiêu không được để trống");
            }
            var listClo = await _tbl_NHCH_CloRepos.GetAllLazy().ToListAsync();
            foreach (var item in listMucTieu)
            {

                var listMaClo = item.ListClo.Split(";").ToList();
                var listItemClo = listClo.Where(x => listMaClo.Contains(x.Code)).ToList();

                item.NHCH_MucTieu_Clos = new List<NHCH_MucTieu_Clo>();
                foreach (var a in listItemClo)
                {
                    var itemClo = new NHCH_MucTieu_Clo()
                    {
                        IdMucTieu = item.Id,
                        IdClo = a.Id,
                        MaClo = a.Code,
                        CreatedBy = _userPrincipalService.UserId.ToString(),
                        ModifiedBy = _userPrincipalService.UserId.ToString(),
                        Created = DateTime.UtcNow,
                        Modified = DateTime.UtcNow,
                        InstanceId = Guid.NewGuid(),
                    };
                    item.NHCH_MucTieu_Clos.Add(itemClo);
                }
                item.CreatedBy = _userPrincipalService.UserId.ToString();
                item.ModifiedBy = _userPrincipalService.UserId.ToString();
                item.Created = DateTime.UtcNow;
                item.Modified = DateTime.UtcNow;
                item.InstanceId = Guid.NewGuid();

                await _repos.InsertAsync(item);
            }

            return new MethodResult<object>()
            {
                Success = true,
                Data = listMucTieu,
                Message = "Thành công"
            };
        }
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_MucTieu item)
        //    {
        //        item.MarkDirty<NHCH_MucTieu>(x => new 
        //        {
        //            item.Code,
        //item.Created,
        //item.CreatedBy,
        //item.Entity,
        //item.EntityKey,
        //item.IsBuildIn,
        //item.IsBuildInAll,
        //item.IsDeleted,
        //item.Modified,
        //item.ModifiedBy,
        //item.MoTa,
        //item.ServiceCode,
        //item.Ten,
        //item.Version,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
    }
}