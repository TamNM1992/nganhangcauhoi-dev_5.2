

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
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangCauHoi.Data.Models
{
    ///<summary>
    ///Chưa có description cụ thể
    ///</summary>

    /// Regex để replace các dòng Key: \[ Key.*\n: Bỏ dấu cách giữa [ và Key
    [MessagePackObject(keyAsPropertyName: true)]
    public partial class NHCH_CauHoi : BaseModel//, IBaseModel
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
		///Học phần
		///</summary>
		public Guid IdHocPhan {get;set;}
		///<summary>
		///Mức độ
		///</summary>
		public Guid IdMucDo {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsDeleted {get;set;}
		///<summary>
		///Cờ khả dụng
		///</summary>
		public bool KhaDung {get;set;}
		///<summary>
		///Mã học phần
		///</summary>
		public string MaHocPhan {get;set;}
		///<summary>
		///Mã mức độ
		///</summary>
		public string MaMucDo {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Modified {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string ModifiedBy {get;set;}
		///<summary>
		///Nội dung
		///</summary>
		public string NoiDung {get;set;}
		///<summary>
		///Nội dung
		///</summary>
		public string NoiDungRutGon {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public int STTCauHoi {get;set;}
		///<summary>
		///Tín chỉ
		///</summary>
		public int TinChi {get;set;}


		public Guid InstanceId { get; set; }


		public virtual ICollection<NHCH_CauHoi_Clo> NHCH_CauHoi_Clos  {get;set;} = new HashSet<NHCH_CauHoi_Clo>();
		[NotMapped]
		public Guid IdMaTranDeThiChiTiet { get; set; }

		[NotMapped]
		public int? ThuTu { get; set; }

		[NotMapped]
		public string DanhSachClo { get; set; }

		[NotMapped]
		public Guid IdBoCauHoi { get; set; }

		[NotMapped]
		public string MaBoCauHoi { get; set; }

		[NotMapped]
		public List<NHCH_CauHoi_Clo> DanhSachCLOs { get; set; } = new List<NHCH_CauHoi_Clo>();


	}
    public static class NHCH_CauHoiExtension 
    {
        public static NHCH_CauHoi Clone(this NHCH_CauHoi item)
        {
            return new NHCH_CauHoi
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				Diem = item.Diem,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdChuDe = item.IdChuDe,
				IdHocPhan = item.IdHocPhan,
				IdMucDo = item.IdMucDo,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				KhaDung = item.KhaDung,
				MaHocPhan = item.MaHocPhan,
				MaMucDo = item.MaMucDo,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				NoiDung = item.NoiDung,
				NoiDungRutGon = item.NoiDungRutGon,
				//ServiceCode = item.ServiceCode,
				STTCauHoi = item.STTCauHoi,
				TinChi = item.TinChi,
				//Version = item.Version,
            };
        }
    }
}