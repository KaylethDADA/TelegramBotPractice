using MapsterMapper;
using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Application.Interfaces;
using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Application.Services
{
    public class BookService
    {
        private IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public BookResponse Create(BookCreateRequests request)
        {
            var book = _mapper.Map<Book>(request);
            _bookRepository.Create(book);
            return _mapper.Map<BookResponse>(book);
        }
        public BookResponse Update(BookUpdateRequests request)
        {
            var book = _bookRepository.GetById(request.Id);

            if (book == null)
                throw new Exception();

            book.Update(request.Name, request.Description);
            _bookRepository.Update(book);

            return _mapper.Map<BookResponse>(book);
        }
        public List<BookItemList> GetAll()
        {
            var books = _bookRepository.GetAll();
            return _mapper.Map<List<BookItemList>>(books);
        }
        public BookResponse GetById(Guid id)
        {
            var book = _bookRepository.GetById(id);
            return _mapper.Map<BookResponse>(book);
        }
        public void Delete(Guid id)
        {
            _bookRepository.Delete(id);
        }
    }
}
