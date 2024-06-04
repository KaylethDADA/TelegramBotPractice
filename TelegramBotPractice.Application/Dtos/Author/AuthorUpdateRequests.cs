namespace TelegramBotPractice.Application.Dtos.Author
{
    public sealed record AuthorUpdateRequests(
        Guid Id,
        string? FirstName,
        string? LastName,
        string? MiddleName);
}
