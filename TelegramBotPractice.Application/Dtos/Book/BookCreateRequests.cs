namespace TelegramBotPractice.Application.Dtos.Book
{
    public sealed record BookCreateRequests(
        string Name,
        string Description,
        DateTime YearOfIssue,
        Guid AuthorId);
}
