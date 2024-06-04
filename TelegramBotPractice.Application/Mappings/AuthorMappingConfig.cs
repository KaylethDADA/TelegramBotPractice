using Mapster;
using TelegramBotPractice.Application.Dtos.Author;
using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Application.Mappings
{
    public class AuthorMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthorCreateRequests, Author>()
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.MiddleName, src => src.MiddleName);

            config.NewConfig<Author, AuthorResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.MiddleName, src => src.MiddleName);
        }
    }
}
