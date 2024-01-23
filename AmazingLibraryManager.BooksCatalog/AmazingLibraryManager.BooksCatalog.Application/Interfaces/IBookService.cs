using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.ViewModels;
using AmazingLibraryManager.BooksCatalog.Core.ValueObjects;

namespace AmazingLibraryManager.BooksCatalog.Application.Interfaces
{
    public interface IBookService
    {
        Task<BookViewModel> AddBook(InsertBookInputModel model);
        Task<BookViewModel> UpdateBook(InsertBookInputModel model);
        Task DeleteBook(Guid id);
        Task<List<BookViewModel>> GetAvailibleBooks();
        Task<List<BookViewModel>> GetAllBooks();
        Task<BookViewModel?> GetById(Guid bookId);
        Task<List<BookReview>> GetBookReviews(Guid bookId);
        Task AddBookReview(Guid bookId, AddBookReviewInputModel model);
        Task RegisterBookLoan(Guid id);
        Task RegisterBookReturn(Guid id);
    }
}
