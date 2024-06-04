namespace TelegramBotPractice.Application.Dtos.Book
{
    public sealed record BookItemList(
        Guid Id,
        string Name,
        Guid AuthorId);
}
