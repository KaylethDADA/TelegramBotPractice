using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TelegramBotPractice.Api.Controllers.Models;
using TelegramBotPractice.Api.Options;
using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Application.Dtos.Reporting;
using TelegramBotPractice.Application.Services;
using TelegramBotPractice.Reporting.MicrosoftOffice.Enums;

namespace TelegramBotPractice.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServerInfoController : ControllerBase
    {
        private readonly ExcelReportSettings _excelReportSettings;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ServerInfoController(IWebHostEnvironment hostingEnvironment, IOptions<ExcelReportSettings> excelReportSettings)
        {
            _hostingEnvironment = hostingEnvironment;
            _excelReportSettings = excelReportSettings.Value;
        }

        [HttpGet("GetInfo")]
        public IActionResult GetInfo()
        {
            return Ok(DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet("GetMostFavoritedBooksExcel")]
        public IActionResult GetMostFavoritedBooksExcel([FromBody] WebSaveReportingRequests requests, [FromServices] ReportingService service)
        {
            var filePath = service.SaveExcelReport(new SaveReportingRequests(
                requests.FileName, 
                _hostingEnvironment.WebRootPath,
                _excelReportSettings.FilePath,
               FileExtensionTypeEnum.xlsx,
               service.GenerateExcelReport()
               ));

            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(filePath));
        }

        [Authorize]
        [HttpGet("GetPagedBook")]
        public IActionResult GetPagedBook([FromQuery] BookListRequest request, [FromServices] BookService service)
        {
            var res = service.GetPagedBook(request);
            return Ok(res);
        }
    }
}
