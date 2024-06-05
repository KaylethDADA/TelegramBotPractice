using TelegramBotPractice.Domain.Primitives;
using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Domain.Entities
{
    public class User : BaseEntity
    {
        public long ChatId { get; set; }
        public FullName FullName { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<Favorit> Favorits { get; set; }

        public User Update(string? fistName, string? lastName, string? middleName, string? userName)
        {
            FullName.Update(fistName, lastName, middleName);

            if (userName != null)
                Username = userName;

            return this;
        }
    }
}
