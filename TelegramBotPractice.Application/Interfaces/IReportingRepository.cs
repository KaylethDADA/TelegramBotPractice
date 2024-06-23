using TelegramBotPractice.Application.Dtos.Reporting;

namespace TelegramBotPractice.Application.Interfaces
{
    public interface IReportingRepository
    {
        List<MostFavoritedBook> GetMostFavoritedBooks();
        string SaveExcelReport(byte[] fileContents);
    }
}
