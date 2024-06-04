using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotPractice.Api.Command.Interfaces;

namespace TelegramBotPractice.Api.Command
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ITelegramBotClient _botClient;

        public CommandExecutor(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task Execute(Update update)
        {
            if (update.Message!.Chat == null && update.CallbackQuery == null)
                return;


            if(update.Type == UpdateType.CallbackQuery)
            {
                return;
            }

            if(update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {

                var chatId = update.Message.Chat.Id;
                var messageText = "Ваше сообщение получено и обработано!";

                await _botClient.SendTextMessageAsync(chatId, messageText);
            }
        }
    }
}
