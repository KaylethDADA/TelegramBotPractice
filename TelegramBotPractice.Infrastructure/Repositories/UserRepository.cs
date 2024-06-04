﻿using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Domain;
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
        public User GetById(Guid id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id)!;
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