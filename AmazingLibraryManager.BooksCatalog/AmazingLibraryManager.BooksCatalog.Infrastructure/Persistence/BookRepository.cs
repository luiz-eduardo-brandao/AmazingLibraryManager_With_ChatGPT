using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using System.Net;

namespace AmazingLibraryManager.BooksCatalog.Infrastructure.Persistence
{
    internal class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
        }

        public Task AddBookAsync(Book book)
        {
            _books.Add(book);

            return Task.CompletedTask;
        }

        public Task<List<Book>> GetAvalibleBooks()
        {
            return Task.FromResult(_books);
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

        public Task UpdateBookAsync(Book book)
        {
            var result = _books.SingleOrDefault(b => b.Id == book.Id);

            result = book;

            return Task.CompletedTask;
        }
    }
}
