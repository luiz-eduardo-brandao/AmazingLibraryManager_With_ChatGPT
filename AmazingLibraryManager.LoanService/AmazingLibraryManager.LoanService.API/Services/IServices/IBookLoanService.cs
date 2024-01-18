using AmazingLibraryManager.LoanService.API.Domain.Entities;

namespace AmazingLibraryManager.LoanService.API.Services.IServices
{
    public interface IBookLoanService
    {
        Task<List<BookLoan>> GetAll();
        Task<BookLoan> GetByUserId(Guid id);
    }
}