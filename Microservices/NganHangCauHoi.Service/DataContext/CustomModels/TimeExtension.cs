using System;
using System.Collections.Generic;
using System.Text;

namespace NganHangCauHoi.Data.CustomModels
{ 
    public class TimeExtension
    {

        public static string GetStringDateTime(DateTime date, string format = "dd/MM/yyyy")
        {
            return date.ToString(format);
        }

    }
}
