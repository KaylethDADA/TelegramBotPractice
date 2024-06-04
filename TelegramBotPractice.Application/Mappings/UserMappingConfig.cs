using Mapster;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Application.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserCreateRequests, User>()
                .Map(dest => dest.Name, opt => opt.Name);

            config.NewConfig<User, UserResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
