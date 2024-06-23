using MapsterMapper;
using TelegramBotPractice.Application.Dtos.Genre;
using TelegramBotPractice.Application.Interfaces.RepositoryInterfaces;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Services
{
    public class GenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public GenreResponse Create(GenreCreateRequests request)
        {
            var genre = _mapper.Map<Genre>(request);
            _genreRepository.Create(genre);
            return _mapper.Map<GenreResponse>(genre);
        }
        public GenreResponse Update(GenreUpdateRequests request)
        {
            var genre = _genreRepository.GetById(request.Id);

            if (genre == null)
                throw new Exception();

            genre.Update(request.Name, request.Description);
            _genreRepository.Update(genre);

            return _mapper.Map<GenreResponse>(genre);
        }
        public GenreResponse GetById(Guid id)
        {
            var genre = _genreRepository.GetById(id);
            return _mapper.Map<GenreResponse>(genre);
        }
        public List<GenreItemList> GetAll()
        {
            var genres = _genreRepository.GetAll();
            return _mapper.Map<List<GenreItemList>>(genres);
        }
        public void Delete(Guid id)
        {
            _genreRepository.Delete(id);
        }
    }
}
