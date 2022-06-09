

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.All.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NganHangCauHoi.Service.WrapServices.Interfaces;

namespace NganHangCauHoi.API.Controllers
{
    [ApiController]
    public partial class NHCH_MaTranDeThi_ChiTietController
    {
        public NHCH_MaTranDeThi_ChiTietController(
            ILogService logger, 
            INHCH_MaTranDeThi_ChiTietWrapService service) 
            : base(logger, service)
        {
        }
    }
}
