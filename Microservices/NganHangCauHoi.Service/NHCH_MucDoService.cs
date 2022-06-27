

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
using NganHangCauHoi.Repositorys.Interfaces;

namespace NganHangCauHoi.Service
{
    public partial class NHCH_MucDoService 
    {
        public NHCH_MucDoService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_MucDoService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}

        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly INHCH_MucDoRepos _repos;

        public NHCH_MucDoService(INHCH_MucDoRepos repos, IServiceProvider serviceProvider, IEntityChangedEventService entityChangedEventService)
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
        }
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_MucDo item)
        {
            item.MarkDirty<NHCH_MucDo>(x => new
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
                item.MucDo,
                item.ServiceCode,
                item.Ten,
                item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}