using TelegramBotPractice.Domain.Primitives;

namespace TelegramBotPractice.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime YearOfIssue { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public List<BookOfGenre> Genres { get; set; }

        public Book Update(string? name, string description)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;

            if (!string.IsNullOrEmpty(description))
                Description = description;

            return this;
        }
    }
}
