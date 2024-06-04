using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Domain;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext db;

        public AuthorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Author> Create(Author x)
        {
            await db.Authors.AddAsync(x);
            await db.SaveChangesAsync();
            return x;
        }
        public Author Update(Author x)
        {
            db.Authors.Update(x);
            db.SaveChanges();
            return x;
        }
        public Author GetById(Guid id)
        {
            return db.Authors.FirstOrDefault(x => x.Id == id)!;
        }
        public bool Delete(Guid id)
        {
            var user = GetById(id);

            if (user == null)
                throw new Exception();

            db.Authors.Remove(user);
            db.SaveChanges();
            return true;
        }
    }
}
