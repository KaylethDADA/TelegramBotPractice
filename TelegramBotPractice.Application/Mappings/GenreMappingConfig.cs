using Mapster;
using TelegramBotPractice.Application.Dtos.Genre;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Mappings
{
    public class GenreMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GenreCreateRequests, Genre>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);

            config.NewConfig<Genre, GenreResponse>()
                .Map(dest => dest.Id, src => src.Id) 
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);

            config.NewConfig<Genre, GenreItemList>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
