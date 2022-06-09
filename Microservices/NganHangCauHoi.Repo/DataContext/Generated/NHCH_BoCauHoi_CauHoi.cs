

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
    public partial class NHCH_BoCauHoi_CauHoi : BaseModel//, IBaseModel
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
		public Guid IdBoCauHoi {get;set;}
		///<summary>
		///Câu hỏi
		///</summary>
		public Guid IdCauHoi {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsDeleted {get;set;}
		///<summary>
		///Mã bộ câu hỏi
		///</summary>
		public string MaBoCauHoi {get;set;}
		///<summary>
		///Mã câu hỏi
		///</summary>
		public string MaCauHoi {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Modified {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string ModifiedBy {get;set;}
        
        public virtual NHCH_BoCauHoi NHCH_BoCauHoi {get;set;}
		
    }
    public static class NHCH_BoCauHoi_CauHoiExtension 
    {
        public static NHCH_BoCauHoi_CauHoi Clone(this NHCH_BoCauHoi_CauHoi item)
        {
            return new NHCH_BoCauHoi_CauHoi
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdBoCauHoi = item.IdBoCauHoi,
				IdCauHoi = item.IdCauHoi,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				MaBoCauHoi = item.MaBoCauHoi,
				MaCauHoi = item.MaCauHoi,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				//ServiceCode = item.ServiceCode,
				//Version = item.Version,
            };
        }
    }
}