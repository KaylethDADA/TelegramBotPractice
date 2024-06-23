namespace TelegramBotPractice.Application.Dtos.Authentications
{
    public sealed record LoginRequest(
        string UserName,
        string Password);
}
