namespace TelegramBotPractice.Application.Dtos.Book
{
    public sealed record BookOfAuthorResponse(
        Guid Id,
        string Name,
        string Description,
        DateTime YearOfIssue,
        string AuthorFullName
        );
}
