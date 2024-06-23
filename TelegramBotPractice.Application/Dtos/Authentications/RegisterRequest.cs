using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.Application.Dtos.Authentications
{
    public sealed record RegisterRequest(
         string UserName,
         FullName FullName,
         string Password);
}
