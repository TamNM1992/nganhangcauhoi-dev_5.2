using NganHangCauHoi.Data.Models;
using System;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_BoCauHoiRepos 
	{
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_BoCauHoiRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider) 
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

	}
}

    