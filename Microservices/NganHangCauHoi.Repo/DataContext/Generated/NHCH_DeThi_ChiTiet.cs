

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
    public partial class NHCH_DeThi_ChiTiet : BaseModel//, IBaseModel
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
		public decimal Diem {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid Id {get;set;}
		///<summary>
		///Câu hỏi
		///</summary>
		public Guid? IdCauHoi {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid? IdDeThi {get;set;}
		///<summary>
		///Ma trận đề thi chi tiết
		///</summary>
		public Guid? IdMaTranDeThiChiTiet {get;set;}
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
		///Thứ tự
		///</summary>
		public int? ThuTu {get;set;}
        
        public virtual NHCH_DeThi NHCH_DeThi {get;set;}
		
    }
    public static class NHCH_DeThi_ChiTietExtension 
    {
        public static NHCH_DeThi_ChiTiet Clone(this NHCH_DeThi_ChiTiet item)
        {
            return new NHCH_DeThi_ChiTiet
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				Diem = item.Diem,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdCauHoi = item.IdCauHoi,
				IdDeThi = item.IdDeThi,
				IdMaTranDeThiChiTiet = item.IdMaTranDeThiChiTiet,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				//ServiceCode = item.ServiceCode,
				ThuTu = item.ThuTu,
				//Version = item.Version,
            };
        }
    }
}