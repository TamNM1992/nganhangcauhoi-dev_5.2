

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
    public partial class NHCH_BoCauHoiController
    {
        private readonly ILogger<NHCH_BoCauHoiController> _logger;
        private readonly INHCH_BoCauHoiService _service;
        //public NHCH_BoCauHoiController(ILogService logger, INHCH_BoCauHoiWrapService service) : base(logger, service)
        //{
        //}
        public NHCH_BoCauHoiController(ILogger<NHCH_BoCauHoiController> logger, INHCH_BoCauHoiService service) : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("ExportFileCauHoi")]
        public async Task<IActionResult> ExportFileCauHoi(int idBoCauHoi)
        {
            var result = await _service.ExportFileCauHoi(idBoCauHoi);
            return ResponseResult(result);
        }
    }
}
