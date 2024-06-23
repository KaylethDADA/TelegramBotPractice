using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotPractice.Telegram.Interfaces;

namespace TelegramBotPractice.Telegram
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommand[] _commands;

        public CommandExecutor(ICommand[] commands)
        {
            _commands = commands;
        }

        public async Task ExecuteAsync(Update update, CancellationToken cancellationToken)
        {
            if (update.Message != null)
            {
                var command = update.Message.Text;
                await ExecuteCommand(update, cancellationToken, command);
            }

            if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery != null)
            {
                var command = update.CallbackQuery!.Data;
                await ExecuteCommand(update, cancellationToken, command);
            } 
        }

        private async Task ExecuteCommand(Update update, CancellationToken cancellationToken, string command)
        {
            try
            {
                _commands.FirstOrDefault(x => x.NameCommand == command)?.ExecuteAsync(update, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
