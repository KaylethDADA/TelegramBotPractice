using TelegramBotPractice.Application.Dtos.Reporting;

namespace TelegramBotPractice.Application.Interfaces.ReportingInterfaces
{
    public interface IReportingRepository
    {
        List<MostFavoritedBook> GetMostFavoritedBooks();
        string SaveExcelReport(SaveReportingRequests requests);
    }
}
