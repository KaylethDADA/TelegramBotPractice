using Telegram.Bot.Types;

namespace TelegramBotPractice.Api.Command.Interfaces
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}
