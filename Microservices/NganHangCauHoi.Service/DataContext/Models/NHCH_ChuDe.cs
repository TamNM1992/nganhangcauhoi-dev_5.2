

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
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangCauHoi.Data.Models
{
    ///<summary>
    ///Chưa có description cụ thể
    ///</summary>

    /// Regex để replace các dòng Key: \[ Key.*\n: Bỏ dấu cách giữa [ và Key
    [MessagePackObject(keyAsPropertyName: true)]
    public partial class NHCH_ChuDe : BaseModel//, IBaseModel
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
		///Học phần
		///</summary>
		public Guid IdHocPhan {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid IdMucDo {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsDeleted {get;set;}
		///<summary>
		///Mã học phần
		///</summary>
		public string MaHocPhan {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Modified {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string ModifiedBy {get;set;}
		///<summary>
		///Mô tả
		///</summary>
		public string MoTa {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public int MucDo {get;set;}
		///<summary>
		///Tên chủ đề
		///</summary>
		public string Ten {get;set;}
		///<summary>
		///Thứ tự
		///</summary>
		public int? ThuTu {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public int TinChi {get;set;}

		public Guid InstanceId { get; set; }

		public Guid InstanceIdMucDo { get; set; }
		[NotMapped]
		public int IdHP { get; set; }

		[NotMapped]
		public string MaCloStr { get; set; }

		[NotMapped]
		public List<Guid> LstInstanceIdClo { get; set; } = new List<Guid>();

		[NotMapped]
		public string MucDoStr { get; set; }

		public void GenerateTen()
		{
			Ten = $"TC{TinChi} - MD{MucDo} - CD{ThuTu}";
		}

		public virtual ICollection<NHCH_ChuDe_MucTieu> NHCH_ChuDe_MucTieus  {get;set;} = new HashSet<NHCH_ChuDe_MucTieu>();
        
    }
    public static class NHCH_ChuDeExtension 
    {
        public static NHCH_ChuDe Clone(this NHCH_ChuDe item)
        {
            return new NHCH_ChuDe
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdHocPhan = item.IdHocPhan,
				IdMucDo = item.IdMucDo,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				MaHocPhan = item.MaHocPhan,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				MoTa = item.MoTa,
				MucDo = item.MucDo,
				//ServiceCode = item.ServiceCode,
				Ten = item.Ten,
				ThuTu = item.ThuTu,
				TinChi = item.TinChi,
				//Version = item.Version,
            };
        }
    }
}