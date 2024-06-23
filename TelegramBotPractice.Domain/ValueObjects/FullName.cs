using TelegramBotPractice.Domain.Primitives;

namespace TelegramBotPractice.Domain.ValueObjects
{
    public class FullName : BaseValueObjects
    {
        public FullName(string firstName, string? lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;

        }

        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = null;
        public string? MiddleName { get; set; } = null;

        public FullName Update(string? firstName, string? lastName, string? middleName)
        {
            if (firstName is not null)
            {
                FirstName = firstName;
            }
            if (lastName is not null)
            {
                LastName = lastName;
            }
            if (middleName is not null)
            {
                MiddleName = middleName;
            }

            return this;
        }
    }
}
