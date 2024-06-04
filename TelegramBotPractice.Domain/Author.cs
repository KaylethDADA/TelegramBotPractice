using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Domain
{
    public class Author : Entity
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = null;
        public List<Book> Books { get; set; }

        public Author Update(string firstName, string lastName, string middleName)
        {
            if (!string.IsNullOrEmpty(firstName))
                FirstName = firstName;

            if (!string.IsNullOrEmpty(lastName))
                LastName = lastName;

            if (!string.IsNullOrEmpty(middleName))
                MiddleName = middleName;

            return this;
        }
    }
}
