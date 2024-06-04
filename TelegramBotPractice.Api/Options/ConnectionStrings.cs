namespace TelegramBotPractice.Api.Options
{
    public class ConnectionStrings
    {
        public static readonly string Configuration = "ConnectionStrings";

        public string TelegramBotDataBase { get; init; } = default!;
    }
}
