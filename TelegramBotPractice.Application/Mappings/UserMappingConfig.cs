using Mapster;
using Telegram.Bot.Types;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Domain.ValueObjects;
using User = TelegramBotPractice.Domain.Entities.User;

namespace TelegramBotPractice.Application.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserCreateRequests, User>()
                .Map(dest => dest.FullName.FirstName, opt => opt.FullName.FirstName)
                .Map(dest => dest.FullName.LastName, opt => opt.FullName.LastName)
                .Map(dest => dest.FullName.MiddleName, opt => opt.FullName.MiddleName);

            config.NewConfig<User, UserResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FullName.FirstName, src => src.FullName.FirstName)
                .Map(dest => dest.FullName.LastName, src => src.FullName.LastName)
                .Map(dest => dest.FullName.MiddleName, src => src.FullName.MiddleName);

            config.NewConfig<Update, UserCreateRequests>()
                        .Map(dest => dest.FullName, src => new FullName
                        (
                               src.Message.From.FirstName,
                               src.Message.From.LastName,
                               null
                        ))
                       .Map(dest => dest.Username, src => src.Message.From.Username)
                       .Map(dest => dest.ChatId, src => src.Message.Chat.Id);
        }
    }
}
