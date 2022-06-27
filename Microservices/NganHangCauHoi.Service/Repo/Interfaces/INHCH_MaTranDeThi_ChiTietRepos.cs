

using NganHangCauHoi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys.Interfaces
{
    public partial interface INHCH_MaTranDeThi_ChiTietRepos
    {
        Task InsertBulkAsync(List<NHCH_MaTranDeThi_ChiTiet> lstInsert);
        Task UpdateBulkAsync(List<NHCH_MaTranDeThi_ChiTiet> lstUpdate);
        Task DeleteManyAsync(object p);
    }
}

    