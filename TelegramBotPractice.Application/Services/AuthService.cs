using TelegramBotPractice.Application.Dtos.Authentications;
using TelegramBotPractice.Application.Interfaces.Authentications;

namespace TelegramBotPractice.Application.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var res = await _authRepository.Login(request);
            return res;
        }

        public async Task Registration(RegisterRequest request)
        {
           await  _authRepository.Registration(request);
        }
    }
}
