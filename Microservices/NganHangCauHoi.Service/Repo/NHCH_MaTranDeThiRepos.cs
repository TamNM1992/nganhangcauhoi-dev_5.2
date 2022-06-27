
using Microsoft.EntityFrameworkCore;
using NganHangCauHoi.Data.Models;
using System;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_MaTranDeThiRepos 
	{
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_MaTranDeThiRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider) 
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

        public async Task<IMethodResult<NHCH_MaTranDeThi>> GetByIdAsyncDeep(Guid id)
        {
            var item = await _dataContext.Set<NHCH_MaTranDeThi>()
                .Include(x => x.NHCH_MaTranDeThi_ChiTiets).FirstOrDefaultAsync(x => x.Id == id);
            return MethodResult<NHCH_MaTranDeThi>.ResultSingleItemOrNotFound(item);
        }
    }
}

    