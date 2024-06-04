namespace TelegramBotPractice.Application.Dtos.Author
{
    public sealed record AuthorResponse(
            Guid Id,
            string FirstName,
            string? LastName,
            string? MiddleName);
}
