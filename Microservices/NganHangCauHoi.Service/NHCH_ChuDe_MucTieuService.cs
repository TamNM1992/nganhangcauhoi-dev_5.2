

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
using NganHangCauHoi.Data.Models.Constants;
using NganHangCauHoi.Repositorys.Interfaces;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_ChuDe_MucTieuService 
    {
        public NHCH_ChuDe_MucTieuService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_ChuDe_MucTieuService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly INHCH_ChuDe_MucTieuRepos _repos;

        public NHCH_ChuDe_MucTieuService(INHCH_ChuDe_MucTieuRepos repos, IServiceProvider serviceProvider, 
                                            IEntityChangedEventService entityChangedEventService
            )
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
        }

        public override async Task<IMethodResult> UpdateAsync(NHCH_ChuDe_MucTieu item)
        {
            item.MarkDirty(nameof(item.IdChuDe));
            item.MarkDirty(nameof(item.InstanceIdClo));
            item.MarkDirty(nameof(item.MaClo));
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
                _entityChangedEventService.EntityUpdated(item.InstanceId, ServiceConstant.SERVICE_NAME, ServiceConstant.ENTITY_TBL_NHCH_CHUDE_MUCTIEU);
            }
            return result;
        }
        //    public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_ChuDe_MucTieu item)
        //    {
        //        item.MarkDirty<NHCH_ChuDe_MucTieu>(x => new 
        //        {
        //            item.IsDeleted,
        //item.Code,
        //item.Created,
        //item.CreatedBy,
        //item.Entity,
        //item.EntityKey,
        //item.IdChuDe,
        //item.IdClo,
        //item.IsBuildIn,
        //item.IsBuildInAll,
        //item.Modified,
        //item.ModifiedBy,
        //item.ServiceCode,
        //item.Version,
        //        });
        //        return await base.UpdateAsync(item);
        //    }
    }
}