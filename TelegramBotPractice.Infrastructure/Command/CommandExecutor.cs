using MapsterMapper;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Application.Services;
using TelegramBotPractice.Infrastructure.Command.Interfaces;

namespace TelegramBotPractice.Infrastructure.Command
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public CommandExecutor(ITelegramBotClient botClient, IMapper mapper, UserService userService)
        {
            _botClient = botClient;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task Execute(Update update, CancellationToken cancellationToken)
        {
            if (update.Message!.Chat == null && update.CallbackQuery == null)
                return;

            if (update.Message != null && update.Message.Text!.Contains(CommandNames.StartCommand))
            {

                var userCreate = _mapper.Map<UserCreateRequests>(update);

                var user = _userService.Create(userCreate);

                await _botClient.SendTextMessageAsync(
                    chatId: update.Message.Chat!.Id,
                    text: $"Привет {user.FullName.FirstName}!",
                    cancellationToken: cancellationToken);
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                return;
            }
        }
    }
}
