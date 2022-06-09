

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using NganHangCauHoi.Service.DataContext;
using NganHangCauHoi.Service.DataContext.Constants;
using System.Threading.Tasks;
using Shared.All.Common.Models;
using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_DeThiService 
    {
        public NHCH_DeThiService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_DeThiService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_DeThi item)
        {
            item.MarkDirty<NHCH_DeThi>(x => new 
            {
                item.Code,
				item.CountOfApprove,
				item.Created,
				item.CreatedBy,
				item.CurrentWorkflowStep,
				item.CurrentWorkflowType,
				item.Entity,
				item.EntityKey,
				item.FileApprovedId,
				item.FileId,
				item.IdBoCauHoi,
				item.IdCaThi,
				item.IdDotThi,
				item.IdHocKy,
				item.IdHocPhan,
				item.IdLichThi,
				item.IdMaTranDeThi,
				item.IdNamHoc,
				item.IdToChucThi,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.IsDeleted,
				item.MaDotThi,
				item.MaHocPhan,
				item.MetadataStatus,
				item.Modified,
				item.ModifiedBy,
				item.NgayThi,
				item.RejectReason,
				item.ServiceCode,
				item.Ten,
				item.ThoiGianLamBai,
				item.TotalCountOfApprove,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}