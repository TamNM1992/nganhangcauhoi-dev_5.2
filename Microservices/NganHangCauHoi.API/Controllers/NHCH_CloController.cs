

///<summary>
///Author:PhucND
///DateCreated:03/18/2022
///</summary>
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
//using Shared.All.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NganHangCauHoi.Data.Models;
using NganHangCauHoi.Service.Interfaces;
using NganHangCauHoi.Service.WrapServices.Interfaces;
using OfficeOpenXml;

namespace NganHangCauHoi.API.Controllers
{
    [ApiController]
    public partial class NHCH_CloController
    {
        //public NHCH_CloController(
        //    ILogService logger, 
        //    INHCH_CloWrapService service) 
        //    : base(logger, service)
        //{
        //}
        private readonly ILogger<NHCH_CloController> _logger;
        private readonly INHCH_CloService _service;
        public NHCH_CloController(ILogger<NHCH_CloController> logger, INHCH_CloService service)
            : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("TaiFileMau")]
        public async Task<IActionResult> TaiFileMau()
        {
            var response = File((await _service.GetFileMauImport()).Data, "application/octet-stream", "FileMauImport.xlsx");
            return response;

        }

        [HttpPost("Import")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Import()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file != null)
                {
                    try
                    {
                        using (var stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);
                            using (ExcelPackage package = new ExcelPackage(stream))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                var endRow = 2;

                                //tìm dòng cuối cùng trong file excel
                                while (true)
                                {
                                    var isHaveValue = false;
                                    for (int i = 1; i < 3; i++)
                                    {
                                        if (!string.IsNullOrEmpty(worksheet.Cells[endRow, i].Value?.ToString()))
                                        {
                                            isHaveValue = true;
                                            break;
                                        }
                                    }
                                    if (!isHaveValue) break;

                                    endRow++;
                                }
                                var list = new List<NHCH_Clo>();
                                for (int startRow = 2; startRow < endRow; startRow++)
                                {

                                    var obj = new NHCH_Clo();
                                    obj.Code = worksheet.Cells[startRow, 1].Value.ToString().Trim();
                                    obj.Ten = worksheet.Cells[startRow, 2].Value.ToString().Trim();
                                    obj.MoTa = worksheet.Cells[startRow, 3].Value.ToString().Trim();
                                    list.Add(obj);

                                }
                                var result = await _service.ImportExcel(list);
                                return ResponseResult(result);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return Ok(MethodResult.ResultWithError("File không hợp lệ"));
                    }

                }
                else
                {
                    return Ok(MethodResult.ResultWithError("File không tồn tại"));
                }

            }
            catch (Exception e)
            {
                return Ok(MethodResult.ResultWithError(e.ToString()));
            }
        }
    }
}
