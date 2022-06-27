
using Microsoft.EntityFrameworkCore;
using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_DeThi_ChiTietRepos 
	{
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_DeThi_ChiTietRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider) 
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

        public async Task<List<Guid>> GetIdCauHoiByIdDeThiAsync(Guid idDeThi)
        {
            var items = await _dataContext.Set<NHCH_DeThi_ChiTiet>().Where(x => x.IdDeThi == idDeThi)
                .Select(x => x.IdCauHoi.Value).ToListAsync();
            return items;
        }
    }
}

    