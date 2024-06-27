using TelegramBotPractice.Application.Paginations;

namespace TelegramBotPractice.Application.Dtos.Book
{
    public class BookListResponse : IPaginationResponse<BookItemList>
    {
        public ICollection<BookItemList> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
