

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
    public partial class NHCH_MucTieuController
    {
        private readonly ILogger<NHCH_MucTieuController> _logger;
        private readonly INHCH_MucTieuService _service;
        //public NHCH_MucTieuController(
        //    ILogService logger, 
        //    INHCH_MucTieuWrapService service) 
        //    : base(logger, service)
        //{
        //}
        public NHCH_MucTieuController(ILogger<NHCH_MucTieuController> logger, INHCH_MucTieuService service)
           : base()
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("getPaged/find")]
        public async Task<IActionResult> find([FromBody] GridInfo gridInfo)
        {
            var re = await _service.Find(gridInfo);
            return Ok(re);
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
                                var list = new List<NHCH_MucTieu>();
                                for (int startRow = 2; startRow < endRow; startRow++)
                                {

                                    var obj = new NHCH_MucTieu();
                                    obj.Code = worksheet.Cells[startRow, 1].Value.ToString().Trim();
                                    obj.Ten = worksheet.Cells[startRow, 2].Value.ToString().Trim();
                                    obj.MoTa = worksheet.Cells[startRow, 4].Value.ToString().Trim();
                                    obj.ListClo = worksheet.Cells[startRow, 3].Value.ToString().Trim();
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
