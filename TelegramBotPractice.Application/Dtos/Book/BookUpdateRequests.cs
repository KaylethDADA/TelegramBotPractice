namespace TelegramBotPractice.Application.Dtos.Book
{
    public sealed record BookUpdateRequests(
        Guid Id,
        string Name,
        string Description);
}
