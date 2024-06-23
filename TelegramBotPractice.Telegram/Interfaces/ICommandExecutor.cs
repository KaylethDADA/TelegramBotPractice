using Telegram.Bot.Types;

namespace TelegramBotPractice.Telegram.Interfaces
{
    public interface ICommandExecutor
    {
        Task ExecuteAsync(Update update, CancellationToken cancellationToken);
    }
}
