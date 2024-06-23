//using Microsoft.AspNetCore.Hosting;
//using TelegramBotPractice.Api.Options;
using TelegramBotPractice.Application.Dtos.Reporting;
using TelegramBotPractice.Application.Interfaces.ReportingInterfaces;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly ApplicationDbContext db;
        //private readonly ExcelReportSettings _excelReportSettings;
        //private readonly IWebHostEnvironment _hostingEnvironment;

        //public ReportingRepository(ApplicationDbContext db, ExcelReportSettings excelReportSettings, IWebHostEnvironment hostingEnvironment)
        //{
        //    this.db = db;
        //    _excelReportSettings = excelReportSettings;
        //    _hostingEnvironment = hostingEnvironment;
        //}

        public List<MostFavoritedBook> GetMostFavoritedBooks()
        {
            var listBooks = db.GetMostFavoritedBooks().ToList();
            return listBooks;
        }

        public string SaveExcelReport(byte[] fileContents)
        {
            //var fileName = "MostFavoritedBooks_Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            //var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _excelReportSettings.FilePath, fileName);

            //Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            //System.IO.File.WriteAllBytes(filePath, fileContents);

            //return filePath;
            return "";
        }
    }
}
