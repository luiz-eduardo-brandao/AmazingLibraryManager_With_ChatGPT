using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using AmazingLibraryManager.BooksCatalog.Core.ValueObjects;
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
                new Book(Guid.NewGuid(), "Harry Potter", "E a Pedra Filosofal", "J.K Rolling", DateTime.Today.AddYears(-20), new List<BookReview>()),
                new Book(Guid.NewGuid(), "Harry Potter", "E a Câmara Secreta", "J.K Rolling", DateTime.Today.AddYears(-19), new List<BookReview>()),
                new Book(Guid.NewGuid(), "Harry Potter", "E o Prisioneiro de Askaban", "J.K Rolling", DateTime.Today.AddYears(-18), new List<BookReview>()),
                new Book(Guid.NewGuid(), "Harry Potter", "E o Cálice de Fogo", "J.K Rolling", DateTime.Today.AddYears(-17), new List<BookReview>()),
                new Book(Guid.NewGuid(), "Harry Potter", "E a Ordem da Fênix", "J.K Rolling", DateTime.Today.AddYears(-16), new List<BookReview>()),
                new Book(Guid.NewGuid(), "Harry Potter", "E o Enigma do Princípe", "J.K Rolling", DateTime.Today.AddYears(-15), new List<BookReview>()),
                new Book(Guid.NewGuid(), "Harry Potter", "E as Relíquias da Morte", "J.K Rolling", DateTime.Today.AddYears(-14), new List<BookReview>())
            };    
        }

        public Task<List<Book>> GetAllBooks()
        {
            return Task.FromResult(_books);
        }

        public Task<List<Book>> GetAvailibleBooks()
        {
            var books = _books.Where(b => !b.IsDeleted && !b.IsLoaned).ToList();

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

        public async Task<List<BookReview>> GetBookReviews(Guid bookId) 
        {
            var result = _books.SingleOrDefault(b => b.Id == bookId)?.Reviews;

            return result;
        }

        public async Task AddBookReview(Guid bookId, BookReview review)
        {
            var result = _books.SingleOrDefault(b => b.Id == bookId);

            result.AddReview(review);

            // result.Reviews.Add(review);

            // result.UpdateReview(result);

            // if (result is null) 
            // {
            //     result = new List<BookReview>() {review};
            // }
            // else 
            // {
            //     result.Add(review);
            // }
        }

        public async Task RegisterBookLoan(Guid bookId) 
        {
            var result = _books.SingleOrDefault(b => b.Id == bookId);

            result.LoanBook();
        }

        public async Task RegisterBookReturn(Guid bookId) 
        {
            var result = _books.SingleOrDefault(b => b.Id == bookId);

            result.ReturnBook();
        }
    }
}
