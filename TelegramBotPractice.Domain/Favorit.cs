namespace TelegramBotPractice.Domain
{
    public class Favorit 
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BookId { get; set; }    
        public Book Book { get; set; }
    }
}
