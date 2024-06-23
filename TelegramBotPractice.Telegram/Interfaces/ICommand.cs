using Telegram.Bot.Types;

namespace TelegramBotPractice.Telegram.Interfaces
{
    public interface ICommand
    {
        string NameCommand { get; }
        Task ExecuteAsync(Update update, CancellationToken cancellationToken);
    }
}
