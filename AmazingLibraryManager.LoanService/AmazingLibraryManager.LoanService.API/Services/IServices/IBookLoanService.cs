using AmazingLibraryManager.LoanService.API.Domain.Entities;
using AmazingLibraryManager.LoanService.API.Models.InputModels;

namespace AmazingLibraryManager.LoanService.API.Services.IServices
{
    public interface IBookLoanService
    {
        Task<List<BookLoan>> GetAll();
        Task<BookLoan> GetByUserId(Guid id);
        Task AddBookLoan(Guid userId, BookLoanInputModel model);
        Task ReturnBookFromLoan(Guid userId, BookLoanInputModel model);
    }
}