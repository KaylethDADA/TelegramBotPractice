using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetAll();
        Book? GetNextBook(Guid? currentBookId);
    }
}
