using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Domain
{
    public class User : Entity
    {
        public string Name { get; set; } = string.Empty;
        public List<Favorit> Favorits { get; set; }

        public User Update(string name)
        {
            Name = name;

            return this;
        }
    }
}
