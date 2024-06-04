using TelegramBotPractice.Domain.Primitives;

namespace TelegramBotPractice.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<BookOfGenre> Books { get; set; }

        public Genre Update(string? name, string? description)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;

            if (!string.IsNullOrEmpty(description))
                Description = description;

            return this;
        }
    }
}
