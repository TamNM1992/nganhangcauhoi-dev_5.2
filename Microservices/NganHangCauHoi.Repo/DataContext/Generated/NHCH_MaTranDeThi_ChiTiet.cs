

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
    public partial class NHCH_MaTranDeThi_ChiTiet : BaseModel//, IBaseModel
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
		///Điểm
		///</summary>
		public decimal? Diem {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid Id {get;set;}
		///<summary>
		///Chủ đề
		///</summary>
		public Guid IdChuDe {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid IdMaTranDeThi {get;set;}
		///<summary>
		///Mức độ
		///</summary>
		public Guid IdMucDo {get;set;}
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
		///Số câu hỏi
		///</summary>
		public int? SoCauHoi {get;set;}
		///<summary>
		///Thứ tự
		///</summary>
		public int? ThuTu {get;set;}
		///<summary>
		///Tín chỉ
		///</summary>
		public int TinChi {get;set;}
        
        public virtual NHCH_MaTranDeThi NHCH_MaTranDeThi {get;set;}
		
    }
    public static class NHCH_MaTranDeThi_ChiTietExtension 
    {
        public static NHCH_MaTranDeThi_ChiTiet Clone(this NHCH_MaTranDeThi_ChiTiet item)
        {
            return new NHCH_MaTranDeThi_ChiTiet
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				Diem = item.Diem,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdChuDe = item.IdChuDe,
				IdMaTranDeThi = item.IdMaTranDeThi,
				IdMucDo = item.IdMucDo,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				//ServiceCode = item.ServiceCode,
				SoCauHoi = item.SoCauHoi,
				ThuTu = item.ThuTu,
				TinChi = item.TinChi,
				//Version = item.Version,
            };
        }
    }
}