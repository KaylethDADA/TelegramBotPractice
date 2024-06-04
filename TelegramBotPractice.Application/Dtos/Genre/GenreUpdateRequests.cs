namespace TelegramBotPractice.Application.Dtos.Genre
{
    public sealed record GenreUpdateRequests(
        Guid Id,
        string? Name,
        string? Description);
}
