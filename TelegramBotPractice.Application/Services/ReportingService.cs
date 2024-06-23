using MapsterMapper;
using OfficeOpenXml;
using TelegramBotPractice.Application.Dtos.Reporting;
using TelegramBotPractice.Application.Interfaces.ReportingInterfaces;

namespace TelegramBotPractice.Application.Services
{
    public class ReportingService
    { 
        private readonly IReportingRepository _reportingBookRepository;
        private readonly IMapper _mapper;

        public ReportingService(IReportingRepository reportingBookRepository, IMapper mapper)
        {
            _reportingBookRepository = reportingBookRepository;
            _mapper = mapper;
        }

        public string SaveExcelReport(byte[] fileContents)
        {
            string pathe = _reportingBookRepository.SaveExcelReport(fileContents);
            return pathe;
        }

        public byte[] GenerateExcelReport()
        {
            var books = _reportingBookRepository.GetMostFavoritedBooks();
            var mappedBooks = _mapper.Map<List<MostFavoritedBook>>(books);
            return GenerateExcelReport(mappedBooks);
        }

        private byte[] GenerateExcelReport(List<MostFavoritedBook> books)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackage = new ExcelPackage())
            {
                var sheet = excelPackage.Workbook.Worksheets.Add("Most Favorited Books");

                // Заголовки столбцов
                sheet.Cells[1, 1].Value = "Name";
                sheet.Cells[1, 2].Value = "Description";
                sheet.Cells[1, 3].Value = "Year of Issue";
                sheet.Cells[1, 4].Value = "FullName Author";
                sheet.Cells[1, 5].Value = "Favorite Count";

                // Данные
                int row = 2;
                foreach (var book in books)
                {
                    sheet.Cells[row, 1].Value = book.Name;
                    sheet.Cells[row, 2].Value = book.Description;
                    sheet.Cells[row, 3].Value = book.YearOfIssue.ToShortDateString();
                    sheet.Cells[row, 4].Value = book.AuthorFullName;
                    sheet.Cells[row, 5].Value = book.FavoriteCount;
                    row++;
                }

                // Автонастройка ширины столбцов
                sheet.Cells.AutoFitColumns();

                // Преобразование в массив байтов для возврата клиенту
                return excelPackage.GetAsByteArray();
            }
        }
    }
}
