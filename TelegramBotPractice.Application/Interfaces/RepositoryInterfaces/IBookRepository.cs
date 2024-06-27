using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        BookListResponse GetPagedBook (BookListRequest request);
        Book? GetNextBook(Guid? currentBookId);
    }
}
