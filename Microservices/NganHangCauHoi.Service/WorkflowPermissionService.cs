

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///</summary>

using System;
using System.Threading.Tasks;
//using Shared.All.Common.Models;
//using Shared.All.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NganHangCauHoi.Data.Models;

namespace NganHangCauHoi.Service
{
    public partial class WorkflowPermissionService 
    {
        public WorkflowPermissionService(
            NganHangCauHoiDataContext dataContext, 
            IServiceProvider serviceProvider)// : base(dataContext, serviceProvider)
        {}
        protected WorkflowPermissionService(
            IServiceProvider serviceProvider) 
        : this(serviceProvider.GetRequiredService<NganHangCauHoiDataContext>(),
                serviceProvider) {}
        
    //    public override async Task<IMethodResult<bool>> UpdateAsync(WorkflowPermission item)
    //    {
    //        item.MarkDirty<WorkflowPermission>(x => new 
    //        {
    //            item.AllowEdit,
				//item.Code,
				//item.Completed,
				//item.Created,
				//item.CreatedBy,
				//item.CurrentStateCode,
				//item.DonViIdLastInWorkflow,
				//item.DonViIds,
				//item.Entity,
				//item.EntityKey,
				//item.GroupIds,
				//item.HemisCode,
				//item.HemisId,
				//item.IdHistory,
				//item.IsBuildIn,
				//item.IsBuildInAll,
				//item.IsDeleted,
				//item.IsPrivate,
				//item.IsPublic,
				//item.ItemId,
				//item.Link,
				//item.Modified,
				//item.ModifiedBy,
				//item.NotInWorkflow,
				//item.Permission,
				//item.PersistedId,
				//item.PrintFileId,
				//item.RoleIds,
				//item.ServiceCode,
				//item.Synced,
				//item.TableName,
				//item.TextTrangThai,
				//item.TrangThai,
				//item.Type,
				//item.UserIdCreated,
				//item.UserIdLastInWorkflow,
				//item.UserIds,
				//item.UserIdsCombine,
				//item.Version,
				//item.WorkflowCode,
				//item.WorkflowCoreStatus,
				//item.WorkflowStateType,
    //        });
    //        return await base.UpdateAsync(item);
    //    }
    }
}