using Telegram.Bot.Types;

namespace TelegramBotPractice.Infrastructure.Command.Interfaces
{
    public interface ICommandExecutor
    {
        Task Execute(Update update, CancellationToken cancellationToken);
    }
}
