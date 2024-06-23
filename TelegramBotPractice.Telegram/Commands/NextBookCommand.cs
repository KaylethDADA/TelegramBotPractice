using Microsoft.Extensions.Caching.Memory;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotPractice.Application.Services;
using TelegramBotPractice.Telegram.Interfaces;

namespace TelegramBotPractice.Telegram.Commands
{
    public class NextBookCommand : ICommand
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IMemoryCache _cache;
        private readonly BookService _bookService;

        public NextBookCommand(
            IMemoryCache cache,
            BookService bookService,
            ITelegramBotClient botClient)
        {
            _cache = cache;
            _bookService = bookService;
            _botClient = botClient;
        }

        public string NameCommand => CommandNames.NextBookCommand;

        public async Task ExecuteAsync(Update update, CancellationToken cancellationToken)
        {
            await SendNextBookInfo(update.CallbackQuery.Message.Chat.Id, cancellationToken);
        }

        private async Task SendNextBookInfo(long chatId, CancellationToken cancellationToken)
        {
            if (!_cache.TryGetValue(chatId, out Guid currentBookId))
            {
                currentBookId = Guid.Empty;
            }

            var nextBook = _bookService.GetNextBook(currentBookId);
            if (nextBook == null)
                return;

            _cache.Set(chatId, nextBook.Id);

            var messageText = $"Название: {nextBook.Name}\n" +
                              $"Автор: {nextBook.AuthorFullName}\n" +
                              $"Описание: {nextBook.Description}\n" +
                              $"Год издания: {nextBook.YearOfIssue.Year}";

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Добавить в избранные", CommandNames.AddFavoritCommand),
                    InlineKeyboardButton.WithCallbackData("Следующая", CommandNames.NextBookCommand)
                }
            });

            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: messageText,
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }
    }
}
