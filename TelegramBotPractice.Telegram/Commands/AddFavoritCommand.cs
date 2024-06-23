using Microsoft.Extensions.Caching.Memory;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotPractice.Application.Services;
using TelegramBotPractice.Telegram.Interfaces;

namespace TelegramBotPractice.Telegram.Commands
{
    public class AddFavoritCommand : ICommand
    {
        private readonly IMemoryCache _cache;
        private readonly ITelegramBotClient _botClient;
        private readonly UserService _userService;

        public AddFavoritCommand(IMemoryCache cache, ITelegramBotClient botClient, UserService userService)
        {
            _cache = cache;
            _botClient = botClient;
            _userService = userService;
        }

        public string NameCommand => CommandNames.AddFavoritCommand;

        public async Task ExecuteAsync(Update update, CancellationToken cancellationToken)
        {
            await AddToFavorites(update.CallbackQuery.Message.Chat.Id, cancellationToken);
        }

        private async Task AddToFavorites(long chatId, CancellationToken cancellationToken)
        {
            if (!_cache.TryGetValue(chatId, out Guid currentBookId))
            {
                currentBookId = Guid.Empty;
            }

            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Книга добавлена в избранные!",
                cancellationToken: cancellationToken);
            
            _userService.AddFavoritBook(chatId, currentBookId);
        }
    }
}
