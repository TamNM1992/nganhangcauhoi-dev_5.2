using MessagePack;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_CauHoi_ImportModel
    {
        public Guid IdHocPhan { get; set; }
        public string MaHocPhan { get; set; }
        public Guid IdChuDe { get; set; }
        public string MaChuDe { get; set; }
        public Guid[] IdCLOs { get; set; }
        public List<SingleClo> DanhSachClo { get; set; }
        public Guid IdMucDo { get; set; }
        public string MaMucDo { get; set; }
        public int TinChi { get; set; }
        public string TienToMaCauHoi { get; set; }
        public string[] NoiDungs { get; set; }
        public decimal? Diem { get; set; }
    }

    public class SingleClo
    {
        public Guid IdClo { get; set; }
        public string MaClo { get; set; }
    }
}
