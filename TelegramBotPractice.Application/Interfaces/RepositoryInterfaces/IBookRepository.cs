using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        List<Book> GetAll();
        Book? GetNextBook(Guid? currentBookId);
    }
}
