using AmazingLibraryManager.LoanService.API.Domain.Entities;

namespace AmazingLibraryManager.LoanService.API.Domain.Repositories
{
    public interface IBookLoanRepository
    {
        Task<List<BookLoan>> GetAllAsync();
        Task<BookLoan> GetByUserIdAsync(Guid id);
        Task AddBookLoan(BookLoan bookLoan);
        Task UpdateBookLoan(BookLoan bookLoan);
    }
}