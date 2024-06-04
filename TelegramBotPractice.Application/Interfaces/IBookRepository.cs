using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Application.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        public List<Book> GetAll();
    }
}
