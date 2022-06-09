

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
    public partial class NHCH_MaTranDeThi_ChiTietService 
    {
        public NHCH_MaTranDeThi_ChiTietService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_MaTranDeThi_ChiTietService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_MaTranDeThi_ChiTiet item)
        {
            item.MarkDirty<NHCH_MaTranDeThi_ChiTiet>(x => new 
            {
                item.Code,
				item.Created,
				item.CreatedBy,
				item.Diem,
				item.Entity,
				item.EntityKey,
				item.IdChuDe,
				item.IdMaTranDeThi,
				item.IdMucDo,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.IsDeleted,
				item.Modified,
				item.ModifiedBy,
				item.ServiceCode,
				item.SoCauHoi,
				item.ThuTu,
				item.TinChi,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}