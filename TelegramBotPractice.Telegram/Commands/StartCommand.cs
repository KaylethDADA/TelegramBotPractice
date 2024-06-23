using MapsterMapper;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Application.Services;
using TelegramBotPractice.Telegram.Interfaces;

namespace TelegramBotPractice.Telegram.Commands
{
    public class StartCommand : ICommand
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public StartCommand(
            IMapper mapper,
            ITelegramBotClient botClient,
            UserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _botClient = botClient;
        }

        public string NameCommand => CommandNames.StartCommand;

        public async Task ExecuteAsync(Update update, CancellationToken cancellationToken)
        {
            var userCreate = _mapper.Map<UserCreateRequests>(update);
            var user = _userService.Create(userCreate);

            await SendWelcomeMessage(update.Message!.Chat.Id, user, cancellationToken);
        }

        private async Task SendWelcomeMessage(long chatId, UserResponse user, CancellationToken cancellationToken)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
{
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Начать просмотр книг!", CommandNames.NextBookCommand)
                }
            });

            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Привет {user.FullName.FirstName}!",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}
