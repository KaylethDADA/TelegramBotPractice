using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TelegramBotPractice.Application.Services;

namespace TelegramBotPractice.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<GenreService>();
            services.AddScoped<BookService>();
            services.AddScoped<AuthorService>();
            services.AddScoped<ReportingService>();

            return services;
        }
    }
}
