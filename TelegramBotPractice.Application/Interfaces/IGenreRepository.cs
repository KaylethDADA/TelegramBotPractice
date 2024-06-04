using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public List<Genre> GetAll();
    }
}
