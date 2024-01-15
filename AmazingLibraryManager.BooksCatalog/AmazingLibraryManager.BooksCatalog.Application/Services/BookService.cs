using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.Interfaces;
using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;

namespace AmazingLibraryManager.BooksCatalog.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<List<Book>> GetAvailibleBooks()
        {
            return await _bookRepository.GetAvailibleBooks();
        }

        public async Task<Book?> GetById(Guid bookId)
        {
            return await _bookRepository.GetBookByIdAsync(bookId);
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

        public async Task DeleteBook(Guid id) 
        {
            var result = await GetById(id);

            if (result is null) throw new NullReferenceException("There's no Book with this Id.");

            if (result.IsDeleted) throw new InvalidOperationException("Book has already deleted.");

            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
