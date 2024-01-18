using AmazingLibraryManager.LoanService.API.Domain.Entities;

namespace AmazingLibraryManager.LoanService.API.Services.IServices
{
    public interface IBookCatalogService
    {
        Task<IEnumerable<Book>> GetAvailibleBooks();
        Task<Book> GetById(Guid id);
    }
}