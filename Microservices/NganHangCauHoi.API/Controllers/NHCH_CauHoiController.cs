

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Intersoft.Crosslight;
//using Shared.All.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NganHangCauHoi.Service.Interfaces;
using NganHangCauHoi.Data.CustomModels;

namespace NganHangCauHoi.API.Controllers
{
    [ApiController]
    public partial class NHCH_CauHoiController
    {
        private readonly ILogger _logger;
        private readonly INHCH_CauHoiService _service;
        //public NHCH_CauHoiController(ILogService logger,  INHCH_CauHoiWrapService service) : base(logger, service)
        //{
        //}
        public NHCH_CauHoiController(ILogger<NHCH_CauHoiController> logger, INHCH_CauHoiService service) : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("ExportByIds")]
        public async Task<IActionResult> ExportByIds([FromBody] int[] idCauHois)
        {
            var fileContent = await _service.ExportByIds(idCauHois);
            var response = File(fileContent, "application/octet-stream", "Export_CauHoi.docx");
            return response;
        }

        [HttpGet("CopyById/{id}")]
        public async Task<IActionResult> CopyById(int id)
        {
            var result = await _service.CopyById(id);
            return ResponseResult(result);
        }

        [HttpGet("CloneAllByTinChi/{num}/{next}")]
        public async Task<IActionResult> CloneAllByTinChi(int num, int next)
        {
            var result = await _service.CloneAllByTinChi(num, next);
            return ResponseResult(result);
        }

        [HttpPost("GetDetailByIds")]
        public async Task<IActionResult> GetDetailByIds(int[] data)
        {
            return ResponseResult(await _service.GetByIdsAsync(data));
        }

        [HttpPost("ImportCauHoiMaTran")]
        public async Task<IActionResult> ImportCauHoiMaTran([FromForm] NHCH_CauHoiMaTranDataModel data)
        {
            try
            {
                var result = await _service.ImportCauHoiMaTran(data.File, data.IdHocPhan, data.MaHocPhan,
                        data.ImportMaTran, data.ImportCauHoi, data.TienTo, data.IdBoCauHoi ?? 0, data.IsTaoBoCauHoi ?? false);
                return ResponseResult(result);
            }
            catch (Exception e)
            {
                return ResponseResult(MethodResult.ResultWithError(Validation.ERR_BUSINESS, message: e.Message));
            }
        }

        [HttpPost("CreateCauHoiFileDefault")]
        public async Task<IActionResult> CreateCauHoiFile([FromForm] NHCH_CreateCauHoiFileModel data)
        {
            if (data != null)
            {
                var result = await _service.CreateCauHoiFileDefault(data.Service, data.Entity, data.EntityInstanceId);
                return ResponseResult(result);
            }
            else
            {
                return ResponseResult(MethodResult.ResultWithError("ERROR_IMPORT_QUESTION_MATRIX", "Lỗi thêm mới câu hỏi và ma trận đề thi từ tệp tin"));
            }
        }

        [HttpPost("GetAllWithoutBoCauHoi")]
        public async Task<IActionResult> GetAllWithoutBoCauHoi(GridInfo gridInfo)
        {
            var result = await _service.GetAllWithoutBoCauHoi(gridInfo);
            return ResponseResult(result);
        }

        [HttpPost]
        [Route("getPaged/FindByDeThi")]
        public async Task<IActionResult> FindByDeThi(GridInfo gridInfo)
        {
            var re = await _service.FindByDeThi(gridInfo);
            return ResponseResult(re);
        }
    }
}
