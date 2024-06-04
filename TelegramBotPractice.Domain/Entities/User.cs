using TelegramBotPractice.Domain.Primitives;
using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Domain.Entities
{
    public class User : BaseEntity
    {
        public long ChatId { get; set; }
        public string Username { get; set; } = string.Empty;
        public FullName FullName { get; set; }
        public List<Favorit> Favorits { get; set; }

        public User Update(long chatId, string? fistName, string? lastName, string? middleName)
        {
            FullName.Update(fistName, lastName, middleName);

            //if(userName != null)
            //    Username = userName;

            return this;
        }
    }
}
