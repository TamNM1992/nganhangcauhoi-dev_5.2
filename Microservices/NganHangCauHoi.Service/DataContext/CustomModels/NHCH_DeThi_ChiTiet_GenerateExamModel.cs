using System;
using System.Collections.Generic;
using System.Text;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_DeThi_ChiTiet_GenerateExamModel
    {
        public Guid IdMaTranDeThi { get; set; }
        public Guid IdHocPhan { get; set; }
        public Guid IdNamHoc { get; set; }
        public Guid IdHocKy { get; set; }
        public Guid? IdDotThi { get; set; }
        public Guid IdDeThi { get; set; }
        public Guid? IdBoCauHoi { get; set; }
        // UD-2450 - TuDN
        //public int SoDeCanSinh { get; set; }
        //public int SoCauTrungTrongDotThi { get; set; }
        //public int SoCauTrungKyTruoc { get; set; }
        // End UD-2450 - TuDN
    }
}
