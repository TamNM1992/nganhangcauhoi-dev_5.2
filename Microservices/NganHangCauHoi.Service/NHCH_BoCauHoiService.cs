

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
    public partial class NHCH_BoCauHoiService 
    {
        public NHCH_BoCauHoiService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_BoCauHoiService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_BoCauHoi item)
        {
            item.MarkDirty<NHCH_BoCauHoi>(x => new 
            {
                item.Code,
				item.Created,
				item.CreatedBy,
				item.Entity,
				item.EntityKey,
				item.IdHocPhan,
				item.IsBuildIn,
				item.IsDeleted,
				item.MaHocPhan,
				item.Modified,
				item.ModifiedBy,
				item.ServiceCode,
				item.SoThuTu,
				item.Ten,
				item.TienTo,
				item.Version,
				item.IsBuildInAll,
            });
            return await base.UpdateAsync(item);
        }
    }
}