using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Application.Services;

namespace TelegramBotPractice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerInfoController : ControllerBase
    {
        [Authorize]
        [HttpGet("GetInfo")]
        public IActionResult GetInfo()
        {
            return Ok(DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet("GetMostFavoritedBooksExcel")]
        public IActionResult GetMostFavoritedBooksExcel([FromServices] ReportingService service)
        {
            var filePath = service.SaveExcelReport(service.GenerateExcelReport());
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
