﻿using MapsterMapper;
using TelegramBotPractice.Application.Dtos.Book;
using TelegramBotPractice.Application.Interfaces.RepositoryInterfaces;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Application.Services
{
    public class BookService
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
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
        public BookListResponse GetPagedBook(BookListRequest request)
        {
            var books = _bookRepository.GetPagedBook(request);
            return books;
        }
        public BookResponse GetById(Guid id)
        {
            var book = _bookRepository.GetById(id);
            return _mapper.Map<BookResponse>(book);
        }
        public BookOfAuthorResponse GetNextBook(Guid id)
        {
            var book = _bookRepository.GetNextBook(id);

            if (book == null)
                throw new Exception();

            var author = _authorRepository.GetById(book.AuthorId);

            return new BookOfAuthorResponse(
                Id: book.Id,
                Name: book.Name,
                Description: book.Description,
                YearOfIssue: book.YearOfIssue,
                AuthorFullName: author.FullName.ToString()
            );
        }
        public void Delete(Guid id)
        {
            _bookRepository.Delete(id);
        }
    }
}
