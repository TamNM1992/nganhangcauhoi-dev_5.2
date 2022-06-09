

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
    public partial class NHCH_MaTranDeThi : BaseModel//, IBaseModel
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
		public Guid? IdHocPhan {get;set;}
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
		///Chưa có description cụ thể
		///</summary>
		public int SoThuTu {get;set;}
		///<summary>
		///Tên
		///</summary>
		public string Ten {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string TienTo {get;set;}
        
		public virtual ICollection<NHCH_MaTranDeThi_ChiTiet> NHCH_MaTranDeThi_ChiTiets  {get;set;} = new HashSet<NHCH_MaTranDeThi_ChiTiet>();
        
    }
    public static class NHCH_MaTranDeThiExtension 
    {
        public static NHCH_MaTranDeThi Clone(this NHCH_MaTranDeThi item)
        {
            return new NHCH_MaTranDeThi
            {
                Code = item.Code,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				Id = item.Id,
				IdHocPhan = item.IdHocPhan,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				MaHocPhan = item.MaHocPhan,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				//ServiceCode = item.ServiceCode,
				SoThuTu = item.SoThuTu,
				Ten = item.Ten,
				TienTo = item.TienTo,
				//Version = item.Version,
            };
        }
    }
}