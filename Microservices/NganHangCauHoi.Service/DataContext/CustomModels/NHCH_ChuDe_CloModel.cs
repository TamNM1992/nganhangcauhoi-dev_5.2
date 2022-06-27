using System;
using System.Collections.Generic;
using System.Text;
using MessagePack;

namespace NganHangCauHoi.Data.CustomModels
{
    [MessagePackObject]
    public class NHCH_ChuDe_CloModel
    {
        [Key(0)]
        public Guid Id { get; set; }
        [Key(1)]
        public string Code { get; set; }
    }
}
