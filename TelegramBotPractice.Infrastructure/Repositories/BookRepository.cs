using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext db;

        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Book> Create(Book x)
        {
            await db.Books.AddAsync(x);
            await db.SaveChangesAsync();
            return x;
        }
        public Book Update(Book x)
        {
            db.Books.Update(x);
            db.SaveChanges();
            return x;
        }
        public List<Book> GetAll()
        {
            return db.Books.ToList();
        }
        public Book GetById(Guid id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id)!;
        }
        public Book? GetNextBook(Guid? currentBookId)
        {

            if (currentBookId == null || currentBookId == Guid.Empty)
            {
                return db.Books.OrderBy(b => b.Id).FirstOrDefault();
            }

            return db.Books.OrderBy(b => b.Id).FirstOrDefault(b => b.Id > currentBookId)!;
        }
        public bool Delete(Guid id)
        {
            var x = GetById(id);

            if (x == null)
                throw new Exception();

            db.Books.Remove(x);
            db.SaveChanges();
            return true;
        }
    }
}
