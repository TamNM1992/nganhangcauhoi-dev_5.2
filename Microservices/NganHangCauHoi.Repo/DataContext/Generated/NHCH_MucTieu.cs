

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
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
    public partial class NHCH_MucTieu : BaseModel//, IBaseModel
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
		///Tên mục tiêu
		///</summary>
		public string Ten {get;set;}
        
		public virtual ICollection<NHCH_MucTieu_Clo> NHCH_MucTieu_Clos  {get;set;} = new HashSet<NHCH_MucTieu_Clo>();
        
    }
    public static class NHCH_MucTieuExtension 
    {
        public static NHCH_MucTieu Clone(this NHCH_MucTieu item)
        {
            return new NHCH_MucTieu
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				//Entity = item.Entity,
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