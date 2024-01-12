using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.Interfaces;
using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using System.ComponentModel.DataAnnotations;

namespace AmazingLibraryManager.BooksCatalog.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBook(InsertBookInputModel model)
        {
            var book = new Book(model.ToEntity());

            await _bookRepository.AddBookAsync(book);

            return book;
        }

        public async Task<Book> UpdateBook(InsertBookInputModel model)
        {
            var book = new Book(model.Id, model.Title, model.SubTitle, model.Author, model.PublishDate);

            await _bookRepository.UpdateBookAsync(book);

            return book;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAvalibleBooks();
        }

        public async Task<Book?> GetById(Guid bookId)
        {
            return await _bookRepository.GetBookByIdAsync(bookId);
        }
    }
}
