using Microsoft.Extensions.DependencyInjection;
using TelegramBotPractice.Application.Interfaces.ReportingInterfaces;
using TelegramBotPractice.Application.Interfaces.RepositoryInterfaces;
using TelegramBotPractice.Infrastructure.Repositories;

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
            services.AddScoped<IReportingRepository, ReportingRepository>();

            return services;
        }
    }
}
