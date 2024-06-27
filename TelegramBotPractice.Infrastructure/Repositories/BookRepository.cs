using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Application.Interfaces.RepositoryInterfaces;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Infrastructure.Context;
using TelegramBotPractice.Application.Paginations;

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
        public BookListResponse GetPagedBook(BookListRequest request)
        {
            var quest = db.Books.AsQueryable();

            var bookList = quest.GetPaginationResponse<Book, BookListResponse, BookItemList>(request, x =>
            new BookItemList
            (
                Id: x.Id,
                Name: x.Name
            ));

            return bookList;
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
