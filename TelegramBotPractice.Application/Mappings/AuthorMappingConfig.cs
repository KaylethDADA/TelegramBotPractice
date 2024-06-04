using Mapster;
using TelegramBotPractice.Application.Dtos.Author;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Mappings
{
    public class AuthorMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthorCreateRequests, Author>()
                .Map(dest => dest.FullName.FirstName, src => src.FirstName)
                .Map(dest => dest.FullName.LastName, src => src.LastName)
                .Map(dest => dest.FullName.MiddleName, src => src.MiddleName);

            config.NewConfig<Author, AuthorResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FirstName, src => src.FullName.FirstName)
                .Map(dest => dest.LastName, src => src.FullName.LastName)
                .Map(dest => dest.MiddleName, src => src.FullName.MiddleName);
        }
    }
}
