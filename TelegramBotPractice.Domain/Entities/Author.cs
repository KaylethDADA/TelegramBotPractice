using TelegramBotPractice.Domain.Primitives;
using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Domain.Entities
{
    public class Author : BaseEntity
    {
        public FullName FullName { get; set; }
        public List<Book> Books { get; set; }

        public Author Update(string firstName, string lastName, string middleName)
        {
            if (!string.IsNullOrEmpty(firstName))
                FullName.FirstName = firstName;

            if (!string.IsNullOrEmpty(lastName))
                FullName.LastName = lastName;

            if (!string.IsNullOrEmpty(middleName))
                FullName.MiddleName = middleName;

            return this;
        }
    }
}
