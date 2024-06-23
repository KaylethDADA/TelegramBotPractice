using TelegramBotPractice.Application.Dtos.Authentications;

namespace TelegramBotPractice.Application.Interfaces.Authentications
{
    public interface IAuthRepository
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task Registration(RegisterRequest request);
    }
}
