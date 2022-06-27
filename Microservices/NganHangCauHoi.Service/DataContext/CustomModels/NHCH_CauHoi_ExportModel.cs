using MessagePack;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace NganHangCauHoi.Data.CustomModels
{ 
    public class NHCH_CauHoi_ExportModel
    {
        public int? soCauHoi { get; set; }
        public decimal? soDiem { get; set; }
        public string noiDung { get; set; }
    }
}
