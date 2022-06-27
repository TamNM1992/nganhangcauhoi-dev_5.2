

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

namespace NganHangCauHoi.API.Controllers
{
    [ApiController]
    public partial class NHCH_MaTranDeThiController
    {
        private readonly ILogger<NHCH_MaTranDeThiController> _logger;
        private readonly INHCH_MaTranDeThiService _service;
        //public NHCH_MaTranDeThiController(
        //    ILogService logger, 
        //    INHCH_MaTranDeThiWrapService service) 
        //    : base(logger, service)
        //{
        //}
        public NHCH_MaTranDeThiController(ILogger<NHCH_MaTranDeThiController> logger, INHCH_MaTranDeThiService service)
            : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("GetPaged/Deep")]
        public async Task<IActionResult> GetPagedDeep(GridInfo gridInfo)
        {
            return ResponseResult(await _service.GetPagedDeep(gridInfo));
        }
    }
}
