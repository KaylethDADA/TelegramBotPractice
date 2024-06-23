using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.Authentications
{
    public sealed record TokenResponse(
        Guid Id,
        FullName FullName,
        string Token);
}
