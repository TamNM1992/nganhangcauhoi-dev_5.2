

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
    public partial class NHCH_CauHoi_Clo// : BaseModel//, IBaseModel
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
		public Guid IdCauHoi {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid IdClo {get;set;}
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
		public Guid InstanceId { get; set; }
		public virtual NHCH_CauHoi NHCH_CauHoi {get;set;}
		public string MaClo { get; set; }
		public Guid InstanceIdClo { get; set; }

	}
	public static class NHCH_CauHoi_CloExtension 
    {
        public static NHCH_CauHoi_Clo Clone(this NHCH_CauHoi_Clo item)
        {
            return new NHCH_CauHoi_Clo
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdCauHoi = item.IdCauHoi,
				IdClo = item.IdClo,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				//ServiceCode = item.ServiceCode,
				//Version = item.Version,
            };
        }
    }
}