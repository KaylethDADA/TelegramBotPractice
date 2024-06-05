using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.User
{
    public sealed record  UserCreateRequests(
        FullName FullName,
        string Username,
        long ChatId);
}
