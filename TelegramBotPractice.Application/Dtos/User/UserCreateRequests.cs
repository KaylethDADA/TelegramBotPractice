using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.User
{
    public sealed record  UserCreateRequests(
        FullName Name,
        long ChatId);
}
