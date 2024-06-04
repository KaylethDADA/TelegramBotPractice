using Microsoft.Extensions.Options;

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
    }
}
