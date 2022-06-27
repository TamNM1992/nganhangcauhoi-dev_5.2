

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///Note: Không sửa lại nội dung này của file này
///</summary>

//using Shared.All.Common.Abstractions.v5;
//using Shared.All.Common.Interfaces.v5;
using MessagePack;

using System;
using System.Collections.Generic;
using PnP.Framework.Provisioning.Model;

namespace NganHangCauHoi.Data.Models
{
    ///<summary>
    ///Chưa có description cụ thể
    ///</summary>

    /// Regex để replace các dòng Key: \[ Key.*\n: Bỏ dấu cách giữa [ và Key
    [MessagePackObject(keyAsPropertyName: true)]
    public partial class NHCH_Clo// : BaseModel//, IBaseModel
    {
	        
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string Code {get;set;}
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
		public Guid Id {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsDeleted {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Modified {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string ModifiedBy {get;set;}
		///<summary>
		///Mô tả
		///</summary>
		public string MoTa {get;set;}
		///<summary>
		///Tên clo
		///</summary>
		public string Ten {get;set;}
        public Guid InstanceId { get; set; }


	}
	public static class NHCH_CloExtension 
    {
        public static NHCH_Clo Clone(this NHCH_Clo item)
        {
            return new NHCH_Clo
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				////Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				MoTa = item.MoTa,
				//ServiceCode = item.ServiceCode,
				Ten = item.Ten,
				//Version = item.Version,
            };
        }
    }
}