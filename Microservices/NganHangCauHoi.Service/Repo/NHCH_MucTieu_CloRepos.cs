using NganHangCauHoi.Data.Models;
using System;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_MucTieu_CloRepos 
	{
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_MucTieu_CloRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider) 
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

	}
}

    