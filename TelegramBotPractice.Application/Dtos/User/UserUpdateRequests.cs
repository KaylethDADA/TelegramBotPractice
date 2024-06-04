namespace TelegramBotPractice.Application.Dtos.User
{
    public sealed record UserUpdateRequests(
        Guid Id,
        string Name
        );
}
