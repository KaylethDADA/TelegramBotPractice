using Mapster;
using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Mappings
{
    public class BookMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BookCreateRequests, Book>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.YearOfIssue, src => src.YearOfIssue)
                .Map(dest => dest.AuthorId, src => src.AuthorId);

            config.NewConfig<Book, BookResponse>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.YearOfIssue, src => src.YearOfIssue)
                .Map(dest => dest.AuthorId, src => src.AuthorId);

            config.NewConfig<Book, BookItemList>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
