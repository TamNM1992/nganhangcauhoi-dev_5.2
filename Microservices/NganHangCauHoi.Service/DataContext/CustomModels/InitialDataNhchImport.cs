using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NganHangCauHoi.Data.CustomModels
{
    public class InitialDataNhchImport
    {
        public List<NHCH_ChuDe> lstChuDe { get; set; }
        public List<tbl_DM_MucDo> lstMucDo { get; set; }
        public Guid InstanceIdHocPhan { get; set; }
        public tbl_HocPhan ItemHocPhan { get; set; }
    }
}
