

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
using NganHangCauHoi.Data.CustomModels;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Service.Interfaces;
using NganHangCauHoi.Service.WrapServices.Interfaces;

namespace NganHangCauHoi.API.Controllers
{
    [ApiController]
    public partial class NHCH_DeThiController
    {
        private readonly ILogger _logger;
        private readonly INHCH_DeThiService _service;
        //public NHCH_DeThiController(
        //    ILogService logger, 
        //    INHCH_DeThiWrapService service) 
        //    : base(logger, service)
        //{
        //}
        public NHCH_DeThiController(ILogger<NHCH_DeThiController> logger, INHCH_DeThiService service)
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

        [HttpGet("GetExamByInstanceIdAsync/{instanceId}")]
        public virtual async Task<IActionResult> GetExamByInstanceIdAsync(Guid instanceId)
        {
            var result = await _service.GetExamByInstanceIdAsync(instanceId);
            return ResponseResult(result);
        }

        [HttpGet("GetByIdFullAsync/{id}")]
        public virtual async Task<IActionResult> GetByIdFullAsync(int id)
        {
            var result = await _service.GetByIdFullAsync(id);
            return ResponseResult(result);
        }

        [HttpPost("GenerateMany")]
        public async Task<IActionResult> GenerateMany(NHCH_DeThi data)
        {
            return ResponseResult(await _service.GenerateMany(data));
        }

        [HttpPost("InDeThi")]
        public async Task<IActionResult> InDeThi(int idDeThi)
        {
            var item = await _service.GetByIdAsync(idDeThi);
            var result = await _service.InDeThi(item.Data);
            return ResponseResult(result);
        }

        [HttpPost("XemTruocDeThi")]
        public async Task<IActionResult> XemTruocDeThi(NHCH_DeThi deThi)
        {
            var result = await _service.XemTruocDeThi(deThi);
            return ResponseResult(result);
        }

        [HttpGet("GetDeThi")]
        public async Task<IActionResult> GetDeThi(Guid idHocPhan, Guid idToChucThi, Guid idCaThi, DateTime ngayThi)
        {
            var rs = await _service.GetDeThi(idHocPhan, idToChucThi, idCaThi, ngayThi);
            return ResponseResult(rs);
        }

        [HttpPost("GetDataForPreviewDeThi")]
        public async Task<IActionResult> GetDataForPreviewDeThi([FromBody] PreviewDeThiRequestModel model)
        {
            var rs = await _service.GetDataForPreviewDeThi(model);
            return ResponseResult(rs);
        }
    }
}
