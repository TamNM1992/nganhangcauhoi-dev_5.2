

using NganHangCauHoi.Data.Models;
using System;
using System.Threading.Tasks;
///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>
namespace NganHangCauHoi.Service.WrapServices.Interfaces
{
    public partial interface INHCH_BoCauHoiWrapService 
    {
        private string GetMaBoCauHoi(string maHocPhan, DateTime created, int soThuTu, string tienTo);
    }
}
