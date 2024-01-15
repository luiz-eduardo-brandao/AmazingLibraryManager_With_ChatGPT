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
            _books = new List<Book> 
            {
                new Book(Guid.NewGuid(), "Harry Potter", "E a Pedra Filosofal", "J.K Rolling", DateTime.Today.AddYears(-20)),
                new Book(Guid.NewGuid(), "Harry Potter", "E a Câmara Secreta", "J.K Rolling", DateTime.Today.AddYears(-19)),
                new Book(Guid.NewGuid(), "Harry Potter", "E o Prisioneiro de Askaban", "J.K Rolling", DateTime.Today.AddYears(-18)),
                new Book(Guid.NewGuid(), "Harry Potter", "E o Cálice de Fogo", "J.K Rolling", DateTime.Today.AddYears(-17)),
                new Book(Guid.NewGuid(), "Harry Potter", "E a Ordem da Fênix", "J.K Rolling", DateTime.Today.AddYears(-16)),
                new Book(Guid.NewGuid(), "Harry Potter", "E o Enigma do Princípe", "J.K Rolling", DateTime.Today.AddYears(-15)),
                new Book(Guid.NewGuid(), "Harry Potter", "E as Relíquias da Morte", "J.K Rolling", DateTime.Today.AddYears(-14))
            };    
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

            result.Delete();

            return Task.CompletedTask;
        }
    }
}
