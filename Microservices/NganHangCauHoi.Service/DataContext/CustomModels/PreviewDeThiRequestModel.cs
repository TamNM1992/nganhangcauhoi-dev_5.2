using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NganHangCauHoi.Data.CustomModels
{
    public class PreviewDeThiRequestModel
    {
        public Guid InstanceIdHocPhan { get; set; }

        public List<NHCH_DeThi_ChiTiet> DeThi_ChiTiets { get; set; } = new List<NHCH_DeThi_ChiTiet>();
    }
}
