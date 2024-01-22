using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.ValueObjects;

namespace AmazingLibraryManager.BooksCatalog.Core.Repositories
{
    public interface IBookRepository
    {
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Guid id);
        Task<Book?> GetBookByIdAsync(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetAvailibleBooks();
        Task<IEnumerable<Book>> GetllLoanedBooks();
        Task<IEnumerable<Book>> GetLoanedBooksByUserId(int userId);
        Task<List<BookReview>> GetBookReviews(Guid bookId);
        Task AddBookReview(Guid bookId, BookReview review);
        Task RegisterBookLoan(Guid bookId);
        Task RegisterBookReturn(Guid bookId);
    }
}
