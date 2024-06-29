using TelegramBotPractice.Application.Dtos.Reporting;
using TelegramBotPractice.Application.Interfaces.ReportingInterfaces;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly ApplicationDbContext db;

        public ReportingRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<MostFavoritedBook> GetMostFavoritedBooks()
        {
            var listBooks = db.GetMostFavoritedBooks().ToList();
            return listBooks;
        }

        public string SaveExcelReport(SaveReportingRequests requests)
        {
            try
            {
                var fileName = $"{requests.FileName}" + DateTime.Now.ToString("yyyyMMddHHmmss") + $".{requests.FileExtension.ToString()}";
                var filePath = Path.Combine(requests.WebRootPath, requests.FilePath, fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                System.IO.File.WriteAllBytes(filePath, requests.fileContents);

                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
