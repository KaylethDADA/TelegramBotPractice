using Microsoft.AspNetCore.Mvc;
using TelegramBotPractice.Application.Services;

namespace TelegramBotPractice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerInfoController : ControllerBase
    {
        [HttpGet("GetInfo")]
        public IActionResult GetInfo() 
        {
            return Ok(DateTime.Now.ToString());
        }

        [HttpGet("GetMostFavoritedBooksExcel")]
        public IActionResult GetMostFavoritedBooksExcel([FromServices] ReportingService service)
        {
            var filePath = service.SaveExcelReport(service.GenerateExcelReport());
            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(filePath));
        }
    }
}
