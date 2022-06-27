

using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys.Interfaces
{
    public partial interface INHCH_DeThi_ChiTietRepos
	{
        Task<List<Guid>> GetIdCauHoiByIdDeThiAsync(Guid idDeThi);
    }
}

    