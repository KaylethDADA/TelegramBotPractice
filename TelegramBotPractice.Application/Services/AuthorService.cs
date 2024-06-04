using MapsterMapper;
using TelegramBotPractice.Application.Dtos.Author;
using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public AuthorResponse Create(AuthorCreateRequests request)
        {
            var author = _mapper.Map<Author>(request);
            _authorRepository.Create(author);
            return _mapper.Map<AuthorResponse>(author);
        }
        public AuthorResponse Update(AuthorUpdateRequests request)
        {
            var author = _authorRepository.GetById(request.Id);

            if (author == null)
                throw new Exception();

            author.Update(request.FirstName, request.LastName, request.MiddleName);
            _authorRepository.Update(author);

            return _mapper.Map<AuthorResponse>(author);
        }
        public AuthorResponse GetById(Guid id)
        {
            var author = _authorRepository.GetById(id);
            return _mapper.Map<AuthorResponse>(author);
        }
        public void Delete(Guid id)
        {
            _authorRepository.Delete(id);
        }
    }
}
