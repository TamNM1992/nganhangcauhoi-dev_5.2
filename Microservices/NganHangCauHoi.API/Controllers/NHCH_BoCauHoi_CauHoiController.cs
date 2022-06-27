

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Shared.All.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NganHangCauHoi.Service.Interfaces;
using NganHangCauHoi.Service.WrapServices.Interfaces;
//using Intersoft.Crosslight;

namespace NganHangCauHoi.API.Controllers
{
    [ApiController]
    public partial class NHCH_BoCauHoi_CauHoiController
    {
        public NHCH_BoCauHoi_CauHoiController(ILogger<NHCH_BoCauHoi_CauHoiController> logger, INHCH_BoCauHoi_CauHoiService service): base()
        {
        }

    }
}
