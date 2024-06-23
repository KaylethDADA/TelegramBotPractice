using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Infrastructure.Context;

namespace TelegramBotPractice.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<User> Create(User user)
        {
            var userChat = GetUserChatId(user.ChatId);

            if(userChat != null)
                return userChat;

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return user;
        }
        public User Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return user;
        }
        public User GetUserChatId(long ChatId)
        {
            return db.Users.FirstOrDefault(x => x.ChatId == ChatId)!;
        }
        public User GetById(Guid id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id)!;
        }
        public User AddFavoritBook(long chatId, Guid bookId)
        {
            var user = GetUserChatId(chatId);

            if (user == null)
                throw new Exception();

            var book = db.Favorits
                .Where(x => x.UserId == user.Id && x.BookId == bookId)
                .FirstOrDefault();

            if (book != null)
                return user;

            db.Favorits.Add(new Favorit { UserId = user.Id, BookId = bookId});
            db.SaveChanges();
            return user;
        }
        public bool Delete(Guid id)
        {
            var user = GetById(id);

            if (user == null)
                throw new Exception();

            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }
    }
}
