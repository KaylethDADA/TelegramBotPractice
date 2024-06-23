using Microsoft.Extensions.DependencyInjection;
using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Infrastructure.Repositories;
using TelegramBotPractice.Infrastructure.Command.Interfaces;
using TelegramBotPractice.Infrastructure.Command;

namespace TelegramBotPractice.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICommandExecutor, CommandExecutor>();
            services.AddScoped<IReportingRepository, ReportingRepository>();

            return services;
        }
    }
}
