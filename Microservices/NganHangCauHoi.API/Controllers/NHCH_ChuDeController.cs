

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
    public partial class NHCH_ChuDeController
    {
        //public NHCH_ChuDeController(
        //    ILogService logger, 
        //    INHCH_ChuDeWrapService service) 
        //    : base(logger, service)
        //{
        //}
        private readonly ILogger<NHCH_ChuDeController> _logger;
        private readonly INHCH_ChuDeService _service;
        public NHCH_ChuDeController(ILogger<NHCH_ChuDeController> logger, INHCH_ChuDeService service) : base()
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
                                var list = new List<NHCH_ChuDe>();
                                for (int startRow = 2; startRow < endRow; startRow++)
                                {

                                    var obj = new NHCH_ChuDe();
                                    obj.Code = worksheet.Cells[startRow, 2].Value.ToString().Trim();
                                    obj.Ten = worksheet.Cells[startRow, 3].Value.ToString().Trim();

                                    var hocphan = worksheet.Cells[startRow, 4].Value.ToString().Trim();
                                    if (!string.IsNullOrEmpty(hocphan))
                                    {
                                        var strIdHocPhan = hocphan.Split(".")[0];
                                        var idhocphan = 0;
                                        if (int.TryParse(strIdHocPhan, out idhocphan))
                                        {
                                            obj.IdHP = idhocphan;
                                        }
                                    }
                                    obj.ListMucTieu = worksheet.Cells[startRow, 5].Value.ToString().Trim();

                                    var thutu = 1;
                                    if (int.TryParse(worksheet.Cells[startRow, 6].Value.ToString().Trim(), out thutu))
                                    {
                                        obj.ThuTu = thutu;
                                    }

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
            return null;
        }

        [HttpPost("GetPaged/Deep")]
        public async Task<IActionResult> GetPageDeep(GridInfo gridInfo)
        {
            return ResponseResult(await _service.GetPageDeep(gridInfo));
        }
    }
}
