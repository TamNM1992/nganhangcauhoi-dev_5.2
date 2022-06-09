

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
    public partial class NHCH_DeThi_ChiTietService 
    {
        public NHCH_DeThi_ChiTietService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_DeThi_ChiTietService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_DeThi_ChiTiet item)
        {
            item.MarkDirty<NHCH_DeThi_ChiTiet>(x => new 
            {
                item.Code,
				item.Created,
				item.CreatedBy,
				item.Diem,
				item.Entity,
				item.EntityKey,
				item.IdCauHoi,
				item.IdDeThi,
				item.IdMaTranDeThiChiTiet,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.IsDeleted,
				item.Modified,
				item.ModifiedBy,
				item.ServiceCode,
				item.ThuTu,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}