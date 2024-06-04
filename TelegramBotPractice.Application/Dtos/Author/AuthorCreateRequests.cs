namespace TelegramBotPractice.Application.Dtos.Author
{
    public sealed record AuthorCreateRequests(
        string FirstName,
        string? LastName,
        string? MiddleName);
}
