﻿using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUserChatId(long ChatId);
        public User AddFavoritBook(long chatId, Guid bookId);
    }
}
