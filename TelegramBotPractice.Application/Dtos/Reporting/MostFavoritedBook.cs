namespace TelegramBotPractice.Application.Dtos.Reporting
{
    public sealed record MostFavoritedBook(
        Guid BookId,
        string Name,
        string Description,
        DateTime YearOfIssue,
        string AuthorFullName,
        int FavoriteCount);
}
