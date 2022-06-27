using System;
using System.Collections.Generic;
using System.Text;
using MessagePack;
using Microsoft.AspNetCore.Http;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_CauHoiMaTranDataModel
    {
        public IFormFile File { get; set; }
        public Guid IdHocPhan { get; set; }
        public string MaHocPhan { get; set; }
        public string TienTo { get; set; }
        public bool ImportMaTran { get; set; }
        public bool ImportCauHoi { get; set; }
        public Guid? IdBoCauHoi { get; set; }
        public bool? IsTaoBoCauHoi { get; set; }
    }
}
