using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotPractice.Infrastructure.Command.Interfaces;

namespace TelegramBotPractice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;

        public BotController(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update, CancellationToken cancellationToken)
        {
            if (update.Message?.Chat == null && update.CallbackQuery == null)
                return Ok();

            await _commandExecutor.Execute(update, cancellationToken);

            return Ok();
        }
    }
}
