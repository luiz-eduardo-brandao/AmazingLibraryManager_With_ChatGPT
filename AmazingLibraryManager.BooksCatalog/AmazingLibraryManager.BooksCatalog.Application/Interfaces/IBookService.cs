using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.Application.Interfaces
{
    public interface IBookService
    {
        Task<Book> AddBook(InsertBookInputModel model);
        Task<Book> UpdateBook(InsertBookInputModel model);
        Task DeleteBook(Guid id);
        Task<List<Book>> GetAvailibleBooks();
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetById(Guid bookId);
    }
}
