using Mapster;
using TelegramBotPractice.Application.Dtos.User;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Mappings
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserCreateRequests, User>()
                .Map(dest => dest.FullName.FirstName, opt => opt.Name.FirstName)
                .Map(dest => dest.FullName.LastName, opt => opt.Name.LastName)
                .Map(dest => dest.FullName.MiddleName, opt => opt.Name.MiddleName);

            config.NewConfig<User, UserResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name.FirstName, src => src.FullName.FirstName)
                .Map(dest => dest.Name.LastName, src => src.FullName.LastName)
                .Map(dest => dest.Name.MiddleName, src => src.FullName.MiddleName);
        }
    }
}
