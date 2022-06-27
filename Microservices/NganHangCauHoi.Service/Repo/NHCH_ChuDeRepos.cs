
using Microsoft.EntityFrameworkCore;
using NganHangCauHoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangCauHoi.Repositorys
{
    public partial class NHCH_ChuDeRepos
    {
        private readonly NganHangCauHoiDataContext _dataContext;
        private readonly IServiceProvider _serviceProvider;
        public NHCH_ChuDeRepos(NganHangCauHoiDataContext dataContext, IServiceProvider serviceProvider)
            : base()
        {
            _dataContext = dataContext;
            _serviceProvider = serviceProvider;
        }

    }
}

