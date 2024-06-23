using Microsoft.AspNetCore.Mvc;
using TelegramBotPractice.Application.Dtos.Authentications;
using TelegramBotPractice.Application.Services;

namespace TelegramBotPractice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] AuthService service)
        {
            var res = await service.Login(request);
            return Ok(res);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterRequest request, [FromServices] AuthService service)
        {
            await service.Registration(request);
            return Ok();
        }
    }
}
