using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.User
{
    public sealed record UserResponse(
        Guid Id,
        FullName FullName);
}
