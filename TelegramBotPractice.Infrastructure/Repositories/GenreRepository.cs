using TelegramBotPractice.Application.Interfaces.RepositoryInterfaces;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext db;

        public GenreRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Genre> Create(Genre x)
        {
            await db.Genres.AddAsync(x);
            await db.SaveChangesAsync();
            return x;
        }
        public Genre Update(Genre x)
        {
            db.Genres.Update(x);
            db.SaveChanges();
            return x;
        }
        public List<Genre> GetAll()
        {
            return db.Genres.ToList();
        }
        public Genre GetById(Guid id)
        {
            return db.Genres.FirstOrDefault(x => x.Id == id)!;
        }
        public bool Delete(Guid id)
        {
            var x = GetById(id);

            if (x == null)
                throw new Exception();

            db.Genres.Remove(x);
            db.SaveChanges();
            return true;
        }
    }
}
