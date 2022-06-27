

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
    public partial class NHCH_MucTieu_CloService 
    {
        public NHCH_MucTieu_CloService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {

        }

        protected NHCH_MucTieu_CloService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}


        private readonly IEntityChangedEventService _entityChangedEventService;
        private readonly INHCH_MucTieu_CloRepos _repos;


        public NHCH_MucTieu_CloService(INHCH_MucTieu_CloRepos repos, IServiceProvider serviceProvider, IEntityChangedEventService entityChangedEventService)
            : base()
        {
            _repos = repos;
            _entityChangedEventService = entityChangedEventService;
        }
        public override async Task<IMethodResult<bool>> UpdateAsync(NHCH_MucTieu_Clo item)
        {
            item.MarkDirty<NHCH_MucTieu_Clo>(x => new
            {
                item.Code,
                item.Created,
                item.CreatedBy,
                item.Entity,
                item.EntityKey,
                item.IdClo,
                item.IdMucTieu,
                item.IsBuildIn,
                item.IsBuildInAll,
                item.IsDeleted,
                item.MaClo,
                item.Modified,
                item.ModifiedBy,
                item.ServiceCode,
                item.Version,
            });
            return await base.UpdateAsync(item);
        }
    }
}