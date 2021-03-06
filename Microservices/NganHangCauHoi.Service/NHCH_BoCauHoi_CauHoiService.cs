

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
    public partial class NHCH_BoCauHoi_CauHoiService 
    {
        private readonly NganHangCauHoiDataContext _context;
        private readonly IServiceProvider _serviceProvider;


        public NHCH_BoCauHoi_CauHoiService( NganHangCauHoiDataContext dataContext,  IServiceProvider serviceProvider) : base()
        {
            _context = dataContext;
            _serviceProvider = serviceProvider;
        }

        protected NHCH_BoCauHoi_CauHoiService( IServiceProvider serviceProvider) : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(), serviceProvider)
        {
        }

        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_BoCauHoi_CauHoi item)
        {
            item.MarkDirty<NHCH_BoCauHoi_CauHoi>(x => new
            {
                item.Code,
                item.Created,
                item.CreatedBy,
                item.Entity,
                item.EntityKey,
                item.IdBoCauHoi,
                item.IdCauHoi,
                item.IsBuildIn,
                item.IsBuildInAll,
                item.IsDeleted,
                item.MaBoCauHoi,
                item.MaCauHoi,
                item.Modified,
                item.ModifiedBy,
                item.ServiceCode,
                item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}