using System;
using System.Collections.Generic;
using System.Text;
using MessagePack;
using Microsoft.AspNetCore.Http;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_CreateCauHoiFileModel
    {
        public string Service { get; set; }
        public string Entity { get; set; }
        public Guid? EntityInstanceId { get; set; }
    }
}
