

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
    public partial class NHCH_MucTieuService 
    {
        public NHCH_MucTieuService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_MucTieuService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_MucTieu item)
        {
            item.MarkDirty<NHCH_MucTieu>(x => new 
            {
                item.Code,
				item.Created,
				item.CreatedBy,
				item.Entity,
				item.EntityKey,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.IsDeleted,
				item.Modified,
				item.ModifiedBy,
				item.MoTa,
				item.ServiceCode,
				item.Ten,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}