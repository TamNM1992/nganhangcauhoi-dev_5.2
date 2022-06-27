using System;
using System.Collections.Generic;
using System.Text;
using MessagePack;

namespace NganHangCauHoi.Data.CustomModels
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class NHCH_DeThi_LichThiModel
    {
        // [Key(200)] 
 	   
        public Guid? IdCaThi { get; set; }
        // [Key(201)] 
 	   
        public Guid? IdToChucThi { get; set; }
        // [Key(202)] 
 	   
        public Guid? IdLichThi { get; set; }
        // [Key(203)] 
 	   
        public DateTime? NgayThi { get; set; }
    }
}
