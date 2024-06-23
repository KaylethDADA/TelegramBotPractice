using Microsoft.Extensions.DependencyInjection;
using TelegramBotPractice.Telegram.Commands;
using TelegramBotPractice.Telegram.Interfaces;

namespace TelegramBotPractice.Telegram
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ICommand, NextBookCommand>();
            services.AddScoped<ICommand, StartCommand>();
            services.AddScoped<ICommand, AddFavoritCommand>();

            services.AddScoped<ICommand[]>(provider =>
            {
                var commandTypes = provider.GetServices<ICommand>();
                return commandTypes.ToArray();
            });

            services.AddScoped<ICommandExecutor, CommandExecutor>();
            return services;
        }
    }
}
