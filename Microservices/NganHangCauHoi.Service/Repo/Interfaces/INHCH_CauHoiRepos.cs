

using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys.Interfaces
{
    public partial interface INHCH_CauHoiRepos
	{
        Task<List<NHCH_CauHoi>> GetByMaTranDeThiChiTiet(NHCH_MaTranDeThi_ChiTiet maTranDeThiChiTiet, List<int> listCauHoiLoaiTru);
        Task<IMethodResult<IEnumerable<NHCH_CauHoi>>> GetAllWithoutBoCauHoi(GridInfo gridInfo, int? currentIdBoCauHoi,
            Guid currentIdHocPhan);
    }
}

    