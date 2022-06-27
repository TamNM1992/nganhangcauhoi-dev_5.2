using System;
using System.Collections.Generic;
using System.Text;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_DeThi_GetExamByInstanceIdModel
    {
        public Guid IdDeThi { get; set; }
        public string TenDeThi { get; set; }
        public string MaDeThi { get; set; }
        public List<CauHoiChiTiet> DanhSachCauHoiChiTiet { get; set; } = new List<CauHoiChiTiet>();
    }

    public class CauHoiChiTiet
    {
        public Guid IdCauHoi { get; set; }
        public Guid InstanceIdCauHoi { get; set; }
        public string MaCauHoi { get; set; }
        public string NoiDungRutGon { get; set; }
        public List<Guid> DanhSachIdClo { get; set; } = new List<Guid>();
        public decimal? Diem { get; set; }
        public int? ThuTu { get; set; }
    }
}
