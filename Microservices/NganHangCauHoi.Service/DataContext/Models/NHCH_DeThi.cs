

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///Note: Không sửa lại nội dung này của file này
///</summary>

//using Shared.All.Common.Abstractions.v5;
//using Shared.All.Common.Interfaces.v5;
using MessagePack;
using NganHangCauHoi.Data.CustomModels;
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
    public partial class NHCH_DeThi //: BaseModel//, IBaseModel
    {
	        public Guid InstanceId { get; set; }
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string Code {get;set;}
		///<summary>
		///Số lần đã approve
		///</summary>
		public int? CountOfApprove {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Created {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string CreatedBy {get;set;}
		///<summary>
		///Quy trình đang chạy đến bước
		///</summary>
		public int? CurrentWorkflowStep {get;set;}
		///<summary>
		///Bản ghi đang apply quy trình nào
		///</summary>
		public int? CurrentWorkflowType {get;set;}
		///<summary>
		///Đề thi (đã duyệt)
		///</summary>
		public Guid? FileApprovedId {get;set;}
		///<summary>
		///Đề thi (chưa duyệt)
		///</summary>
		public Guid? FileId {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public Guid Id {get;set;}
		///<summary>
		///Bộ câu hỏi
		///</summary>
		public Guid? IdBoCauHoi {get;set;}
		///<summary>
		///Ca thi
		///</summary>
		public Guid? IdCaThi {get;set;}
		///<summary>
		///Đợt thi
		///</summary>
		public Guid? IdDotThi {get;set;}
		///<summary>
		///Học kỳ
		///</summary>
		public Guid? IdHocKy {get;set;}
		///<summary>
		///Học phần
		///</summary>
		public Guid? IdHocPhan {get;set;}
		///<summary>
		///Lịch thi
		///</summary>
		public Guid? IdLichThi {get;set;}
		///<summary>
		///Ma trận đề thi
		///</summary>
		public Guid? IdMaTranDeThi {get;set;}
		///<summary>
		///Năm học
		///</summary>
		public Guid? IdNamHoc {get;set;}
		///<summary>
		///Tổ chức thi
		///</summary>
		public Guid? IdToChucThi {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public bool IsDeleted {get;set;}
		///<summary>
		///Mã đợt thi
		///</summary>
		public string MaDotThi {get;set;}
		///<summary>
		///Mã học phần
		///</summary>
		public string MaHocPhan {get;set;}
		///<summary>
		///Trạng thái
		///</summary>
		public int? MetadataStatus {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public DateTime Modified {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public string ModifiedBy {get;set;}
		///<summary>
		///Ngày thi
		///</summary>
		public DateTime? NgayThi {get;set;}
		///<summary>
		///Lý do từ chối
		///</summary>
		public string RejectReason {get;set;}
		///<summary>
		///Tên
		///</summary>
		public string Ten {get;set;}
		///<summary>
		///Chưa có description cụ thể
		///</summary>
		public int ThoiGianLamBai {get;set;}
		///<summary>
		///Tổng số lần cần phải approve
		///</summary>
		public int? TotalCountOfApprove {get;set;}
        
		public virtual ICollection<NHCH_DeThi_ChiTiet> NHCH_DeThi_ChiTiets  {get;set;} = new HashSet<NHCH_DeThi_ChiTiet>();

		[NotMapped]
		public Guid[] IdLichThiList { get; set; }

		[NotMapped]
		public int? SoCauTrungTrongDotThi { get; set; }

		[NotMapped]
		public int? SoCauTrungKyTruoc { get; set; }

		[NotMapped]
		public List<NHCH_DeThi_LichThiModel> LichThiList { get; set; } = new List<NHCH_DeThi_LichThiModel>();

		[NotMapped]
		public List<NHCH_DeThi_ChiTiet> DeThi_ChiTiets { get; set; } = new List<NHCH_DeThi_ChiTiet>();

	}
    public static class NHCH_DeThiExtension 
    {
        public static NHCH_DeThi Clone(this NHCH_DeThi item)
        {
            return new NHCH_DeThi
            {
                Code = item.Code,
				CountOfApprove = item.CountOfApprove,
				Created = item.Created,
				CreatedBy = item.CreatedBy,
				CurrentWorkflowStep = item.CurrentWorkflowStep,
				CurrentWorkflowType = item.CurrentWorkflowType,
				//Entity = item.Entity,
				//EntityKey = item.EntityKey,
				FileApprovedId = item.FileApprovedId,
				FileId = item.FileId,
				Id = item.Id,
				IdBoCauHoi = item.IdBoCauHoi,
				IdCaThi = item.IdCaThi,
				IdDotThi = item.IdDotThi,
				IdHocKy = item.IdHocKy,
				IdHocPhan = item.IdHocPhan,
				IdLichThi = item.IdLichThi,
				IdMaTranDeThi = item.IdMaTranDeThi,
				IdNamHoc = item.IdNamHoc,
				IdToChucThi = item.IdToChucThi,
				//IsBuildIn = item.IsBuildIn,
				//IsBuildInAll = item.IsBuildInAll,
				IsDeleted = item.IsDeleted,
				MaDotThi = item.MaDotThi,
				MaHocPhan = item.MaHocPhan,
				MetadataStatus = item.MetadataStatus,
				Modified = item.Modified,
				ModifiedBy = item.ModifiedBy,
				NgayThi = item.NgayThi,
				RejectReason = item.RejectReason,
				//ServiceCode = item.ServiceCode,
				Ten = item.Ten,
				ThoiGianLamBai = item.ThoiGianLamBai,
				TotalCountOfApprove = item.TotalCountOfApprove,
				//Version = item.Version,
            };
        }
    }
}