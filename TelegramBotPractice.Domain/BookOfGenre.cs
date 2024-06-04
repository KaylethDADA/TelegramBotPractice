namespace TelegramBotPractice.Domain
{
    public class BookOfGenre
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
