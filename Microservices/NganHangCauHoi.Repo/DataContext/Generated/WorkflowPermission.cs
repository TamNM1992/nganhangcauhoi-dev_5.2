

///<summary>
///Author:PhucND
///DateCreated:02/28/2022
///Note: Không sửa lại nội dung này của file này
///</summary>

//using Shared.All.Common.Abstractions.v5;
//using Shared.All.Common.Interfaces.v5;
using MessagePack;
using PnP.Framework.Provisioning.Model;

using System;
using System.Collections.Generic;
namespace NganHangCauHoi.Repo.DataContext
{
    ///<summary>
    ///Chưa có description cụ thể
    ///</summary>

    /// Regex để replace các dòng Key: \[ Key.*\n: Bỏ dấu cách giữa [ và Key
    [MessagePackObject(keyAsPropertyName: true)]
    public partial class WorkflowPermission : BaseModel//, IBaseModel
    {
	        
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool AllowEdit {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string Code {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool Completed {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Created {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string CreatedBy {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string DonViIds {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string GroupIds {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string HemisCode {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid? HemisId {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid Id {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid? IdHistory {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsDeleted {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsPublic {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid ItemId {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string Link {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Modified {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string ModifiedBy {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool NotInWorkflow {get;set;}
		///<summary>
		///Như permission nhị phân của phần phân quyền
		///</summary>
		public int Permission {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public int? PersistedId {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string RoleIds {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool Synced {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string TableName {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string TextTrangThai {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string TrangThai {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public int Type {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid? UserIdCreated {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string UserIds {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string UserIdsCombine {get;set;}
        
        
    }
    public static class WorkflowPermissionExtension 
    {
        public static WorkflowPermission Clone(this WorkflowPermission item)
        {
            return new WorkflowPermission
            {
                AllowEdit = item.AllowEdit,
				Code = item.Code,
				Completed = item.Completed,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				//CurrentStateCode = item.CurrentStateCode,
				//DonViIdLastInWorkflow = item.DonViIdLastInWorkflow,
				DonViIds = item.DonViIds,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				GroupIds = item.GroupIds,
				HemisCode = item.HemisCode,
				HemisId = item.HemisId,
				Id = item.Id,
				IdHistory = item.IdHistory,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				//IsPrivate = item.IsPrivate,
				IsPublic = item.IsPublic,
				ItemId = item.ItemId,
				Link = item.Link,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				NotInWorkflow = item.NotInWorkflow,
				Permission = item.Permission,
				PersistedId = item.PersistedId,
				//PrintFileId = item.PrintFileId,
				RoleIds = item.RoleIds,
				//ServiceCode = item.ServiceCode,
				Synced = item.Synced,
				TableName = item.TableName,
				TextTrangThai = item.TextTrangThai,
				TrangThai = item.TrangThai,
				Type = item.Type,
				UserIdCreated = item.UserIdCreated,
				//UserIdLastInWorkflow = item.UserIdLastInWorkflow,
				UserIds = item.UserIds,
				UserIdsCombine = item.UserIdsCombine,
				//Version = item.Version,
				//WorkflowCode = item.WorkflowCode,
				//WorkflowCoreStatus = item.WorkflowCoreStatus,
				//WorkflowStateType = item.WorkflowStateType,
            };
        }
    }
}