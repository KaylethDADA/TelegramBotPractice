namespace TelegramBotPractice.Application.Dtos.Book
{
    public sealed record BookResponse(
        Guid Id,
        string Name,
        string Description,
        DateTime YearOfIssue,
        Guid AuthorId);
}
