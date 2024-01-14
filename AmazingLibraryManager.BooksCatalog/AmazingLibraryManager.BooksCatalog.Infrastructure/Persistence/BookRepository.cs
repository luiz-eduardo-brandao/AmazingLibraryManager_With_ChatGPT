using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using System.Net;

namespace AmazingLibraryManager.BooksCatalog.Infrastructure.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
        }

        public Task<List<Book>> GetAllBooks()
        {
            return Task.FromResult(_books);
        }

        public Task<List<Book>> GetAvailibleBooks()
        {
            var books = _books.Where(b => !b.IsDeleted).ToList();

            return Task.FromResult(books);
        }

        public Task<Book?> GetBookByIdAsync(Guid id)
        {
            var result = _books.SingleOrDefault(b => b.Id == id);

            return Task.FromResult(result);
        }

        public Task<IEnumerable<Book>> GetllLoanedBooks()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetLoanedBooksByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task AddBookAsync(Book book)
        {
            _books.Add(book);

            return Task.CompletedTask;
        }

        public Task UpdateBookAsync(Book book)
        {
            var result = _books.SingleOrDefault(b => b.Id == book.Id);

            result.Update(book);

            return Task.CompletedTask;
        }

        public Task DeleteBookAsync(Guid id) 
        {
            var result = _books.SingleOrDefault(b => b.Id == id);

            if (result is null) throw new NullReferenceException("There's no Book with this Id.");

            result.Delete();

            return Task.CompletedTask;
        }
    }
}
