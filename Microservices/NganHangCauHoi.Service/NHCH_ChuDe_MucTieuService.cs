

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
    public partial class NHCH_ChuDe_MucTieuService 
    {
        public NHCH_ChuDe_MucTieuService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_ChuDe_MucTieuService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_ChuDe_MucTieu item)
        {
            item.MarkDirty<NHCH_ChuDe_MucTieu>(x => new 
            {
                item.IsDeleted,
				item.Code,
				item.Created,
				item.CreatedBy,
				item.Entity,
				item.EntityKey,
				item.IdChuDe,
				item.IdClo,
				item.IsBuildIn,
				item.IsBuildInAll,
				item.Modified,
				item.ModifiedBy,
				item.ServiceCode,
				item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}