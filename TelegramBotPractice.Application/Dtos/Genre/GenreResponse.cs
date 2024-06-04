namespace TelegramBotPractice.Application.Dtos.Genre
{
    public sealed record GenreResponse(
        Guid Id,
        string Name,
        string Description);
}
