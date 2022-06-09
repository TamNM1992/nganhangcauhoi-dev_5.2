

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
    public partial class NHCH_ChuDeController
    {
        public NHCH_ChuDeController(
            ILogService logger, 
            INHCH_ChuDeWrapService service) 
            : base(logger, service)
        {
        }
    }
}
