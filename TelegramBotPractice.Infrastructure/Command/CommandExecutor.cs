using MapsterMapper;
using Microsoft.Extensions.Caching.Memory;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Application.Services;
using TelegramBotPractice.Infrastructure.Command.Interfaces;

namespace TelegramBotPractice.Infrastructure.Command
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ITelegramBotClient _botClient;
        private readonly UserService _userService;
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CommandExecutor(
            ITelegramBotClient botClient,
            UserService userService,
            BookService bookService,
            IBookRepository bookRepository,
            IMapper mapper,
            IMemoryCache cache,
            AuthorService authorService)
        {
            _botClient = botClient;
            _userService = userService;
            _bookService = bookService;
            _mapper = mapper;
            _cache = cache;
            _authorService = authorService;
        }

        public async Task Execute(Update update, CancellationToken cancellationToken)
        {
            if (update.Message?.Chat == null && update.CallbackQuery == null)
                return;

            if (update.Message != null && update.Message.Text!.Contains(CommandNames.StartCommand))
            {
                var userCreate = _mapper.Map<UserCreateRequests>(update);
                var user = _userService.Create(userCreate);

                await SendWelcomeMessage(update.Message.Chat.Id, user, cancellationToken);
                await SendNextBookInfo(update.Message.Chat.Id, cancellationToken);
            }

            if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery != null)
            {
                var callbackData = update.CallbackQuery.Data;

                if (callbackData == CommandNames.AddFavoritCommand)
                {
                    await AddToFavorites(update.CallbackQuery.Message.Chat.Id, cancellationToken);
                }
                else if (callbackData == CommandNames.NextBookCommand)
                {
                    await SendNextBookInfo(update.CallbackQuery.Message.Chat.Id, cancellationToken);
                }
            }
        }
        private async Task SendWelcomeMessage(long chatId, UserResponse user, CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Привет {user.FullName.FirstName}!",
                cancellationToken: cancellationToken);
        }
        private async Task AddToFavorites(long chatId, CancellationToken cancellationToken)
        {
            if (!_cache.TryGetValue(chatId, out Guid currentBookId))
            {
                currentBookId = Guid.Empty;
            }

            var user = _userService.AddFavoritBook(chatId, currentBookId);

            await _botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Книга добавлена в избранные!",
                cancellationToken: cancellationToken);
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

            var author = _authorService.GetById(nextBook.AuthorId);

            _cache.Set(chatId, nextBook.Id);

            var messageText = $"Название: {nextBook.Name}\n" +
                              $"Автор: {author.FirstName} {author.LastName}\n" +
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
