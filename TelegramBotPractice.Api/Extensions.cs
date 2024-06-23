using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Telegram.Bot;
using TelegramBotPractice.Api.Options;
using TelegramBotPractice.Application.Interfaces.Authentications;

namespace TelegramBotPractice.Api
{
    public static class WebHookExtensions
    {
        public static T GetConfiguration<T>(this IServiceProvider serviceProvider)
            where T : class
        {
            var o = serviceProvider.GetService<IOptions<T>>();

            if (o is null)
                throw new ArgumentNullException(nameof(T));

            return o.Value;
        }
        
        public static ControllerActionEndpointConventionBuilder MapBotWebhookRoute<T>(
            this IEndpointRouteBuilder endpoints,
            string route)
        {
            var controllerName = typeof(T).Name.Replace("Controller", "", StringComparison.Ordinal);
            var actionName = typeof(T).GetMethods()[0].Name;

            return endpoints.MapControllerRoute(
                name: "bot_webhook",
                pattern: route,
                defaults: new { controller = controllerName, action = actionName });
        }

        public static IServiceCollection StartTbBot(this IServiceCollection services)
        {
            // Регистрация HttpClient и TelegramBotClient
           services.AddHttpClient("telegram_bot_client")
                            .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                            {
                                BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
                                TelegramBotClientOptions options = new(botConfig.BotToken);
                                return new TelegramBotClient(options, httpClient);
                            });

            services.AddControllers().AddNewtonsoftJson();
            return services;
        }
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // укзывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,

                    // строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,

                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,

                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,

                    // будет ли валидироваться время существования
                    ValidateLifetime = true,

                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };

            });

            return serviceCollection;
        }
    }
}
