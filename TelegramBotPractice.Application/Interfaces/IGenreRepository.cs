using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Application.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public List<Genre> GetAll();
    }
}
