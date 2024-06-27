using TelegramBotPractice.Application.Paginations;

namespace TelegramBotPractice.Application.Dtos.Book
{
    public class BookListRequest : IPaginationRequest
    {


        public PageRequest? Page { get; set; }
    }
}
