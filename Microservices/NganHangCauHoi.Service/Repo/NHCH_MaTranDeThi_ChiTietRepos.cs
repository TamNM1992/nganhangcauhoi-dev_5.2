
using NganHangCauHoi.Data.Models;
using System;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_MaTranDeThi_ChiTietRepos 
	{
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_MaTranDeThi_ChiTietRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider) 
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

	}
}

    