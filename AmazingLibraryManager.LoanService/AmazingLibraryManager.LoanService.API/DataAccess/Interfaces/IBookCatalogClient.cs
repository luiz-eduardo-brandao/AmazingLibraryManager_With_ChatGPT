using AmazingLibraryManager.LoanService.API.Domain.Entities;
using Refit;

namespace AmazingLibraryManager.LoanService.API.DataAccess.Interfaces
{
    public interface IBookCatalogClient
    {
        [Get("/book/availible")]
        Task<IEnumerable<Book>> GetAvailibleBooks();      

        [Get("/book/{id}")]
        Task<ApiResponse<Book>> GetById(Guid id);         
    }
}