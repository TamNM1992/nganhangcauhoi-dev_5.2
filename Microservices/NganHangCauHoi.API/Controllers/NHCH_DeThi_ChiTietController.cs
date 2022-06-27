

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
    public partial class NHCH_DeThi_ChiTietController
    {
        //public NHCH_DeThi_ChiTietController(
        //    ILogService logger, 
        //    INHCH_DeThi_ChiTietWrapService service) 
        //    : base(logger, service)
        //{
        //}
        private readonly ILogger _logger;
        private readonly INHCH_DeThi_ChiTietService _service;
        public NHCH_DeThi_ChiTietController(ILogger<NHCH_DeThi_ChiTietController> logger, INHCH_DeThi_ChiTietService service) : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("GenerateExam")]
        public async Task<IActionResult> GenerateExam(NHCH_DeThi_ChiTiet_GenerateExamModel data)
        {
            return ResponseResult(await _service.GenerateExam(data));
        }

        [HttpPost("ChangeQuestion")]
        public async Task<IActionResult> ChangeQuestion(NHCH_DeThi_ChiTiet_ChangeQuestionModel data)
        {
            return ResponseResult(await _service.ChangeQuestion(data));
        }

        [HttpPost("ChangeQuestionTo")]
        public async Task<IActionResult> ChangeQuestionTo(NHCH_DeThi_ChiTiet data)
        {
            return ResponseResult(await _service.ChangeQuestionTo(data));
        }
    }
}
