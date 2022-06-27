

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Collections.Generic;
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
    public partial class NHCH_CloService 
    {
        public NHCH_CloService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_CloService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}

        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly IUserPrincipalService _userPrincipalService;
        private readonly INHCH_CloRepos _repos;

        public NHCH_CloService(INHCH_CloRepos repos, IServiceProvider serviceProvider,
                                IEntityChangedEventService entityChangedEventService,
                                IUserPrincipalService userPrincipalService
            )
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
            _userPrincipalService = userPrincipalService;
        }



        public override async Task<IMethodResult> UpdateAsync(NHCH_Clo item)
        {
            item.MarkDirty(nameof(item.Ten));
            item.MarkDirty(nameof(item.MoTa));
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
                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_CLO);
            }
            return result;
        }

        public async Task<IMethodResult<byte[]>> GetFileMauImport()
        {

            using (var xlPackage = new ExcelPackage())
            {
                xlPackage.Workbook.Worksheets.Add("Danh Mục");
                var worksheet = xlPackage.Workbook.Worksheets[0];
                worksheet.Cells[1, 1].Value = "Mã Clo";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Column(1).Width = 15;
                worksheet.Cells[1, 1].Style.Font.Size = 14;
                worksheet.Cells[1, 2].Value = "Tên Clo";
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Font.Size = 14;
                worksheet.Column(2).Width = 25;
                worksheet.Cells[1, 3].Value = "Mô tả";
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Font.Size = 14;
                worksheet.Column(3).Width = 50;

                ExcelRange Rng = worksheet.Cells[1, 1, 1, 3];
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

        public async Task<IMethodResult<object>> ImportExcel(List<NHCH_Clo> listClo)
        {
            var listMa = listClo.Select(x => x.Code).ToList();
            if (_repos.GetAllLazy().Any(x => listMa.Contains(x.Code)))
            {
                return MethodResult<object>.ResultWithError("", 200, "Mã đã tồn tại trong cơ sở dữ liệu");
            }
            foreach (var item in listClo)
            {
                if (string.IsNullOrEmpty(item.Ten))
                {
                    return MethodResult<object>.ResultWithError("", 200, "Tên clo không được để trống");
                }
                item.CreatedBy = _userPrincipalService.UserId.ToString();
                item.ModifiedBy = _userPrincipalService.UserId.ToString();
                item.Created = DateTime.UtcNow;
                item.Modified = DateTime.UtcNow;
                item.InstanceId = Guid.NewGuid();
            }
            await _repos.InsertOrUpdateBulkAsync(listClo);

            return new MethodResult<object>()
            {
                Success = true,
                Data = listClo,
                Message = "Thành công"
            };
        }
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_Clo item)
        //    {
        //        item.MarkDirty<NHCH_Clo>(x => new 
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