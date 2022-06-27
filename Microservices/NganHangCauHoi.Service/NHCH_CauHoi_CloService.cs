

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>

using System;
using System.Threading.Tasks;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NganHangCauHoi.Data.Models;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_CauHoi_CloService 
    {
        public NHCH_CauHoi_CloService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider) //: base(dataContext, serviceProvider)
        {

        }

        protected NHCH_CauHoi_CloService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}

        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_CauHoi_Clo item)
        {
            item.MarkDirty<NHCH_CauHoi_Clo>(x => new
            {
                item.Code,
                item.Created,
                item.CreatedBy,
                item.Entity,
                item.EntityKey,
                item.IdCauHoi,
                item.IdClo,
                item.IsBuildIn,
                item.IsBuildInAll,
                item.IsDeleted,
                item.Modified,
                item.ModifiedBy,
                item.ServiceCode,
                item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}