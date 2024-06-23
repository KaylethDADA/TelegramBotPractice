using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Interfaces.RepositoryInterfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        public List<Genre> GetAll();
    }
}
