using System;
using System.Collections.Generic;
using System.Text;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_DeThi_ChiTiet_ChangeQuestionModel
    {
        public Guid? IdDeThi { get; set; }
        public Guid IdMaTranDeThiChiTiet { get; set; }
        public Guid IdCauHoi { get; set; }
        public int ThuTu { get; set; }
        public Guid? IdBoCauHoi { get; set; }

        public string ListCauHoiLoaiTru { get; set;  }
    }
}
