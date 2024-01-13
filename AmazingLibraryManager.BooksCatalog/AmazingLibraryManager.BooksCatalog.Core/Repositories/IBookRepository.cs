using AmazingLibraryManager.BooksCatalog.Core.Entities;

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
    }
}
