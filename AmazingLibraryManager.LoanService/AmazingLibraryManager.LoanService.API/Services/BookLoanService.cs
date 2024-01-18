using AmazingLibraryManager.LoanService.API.Domain.Entities;
using AmazingLibraryManager.LoanService.API.Domain.Repositories;
using AmazingLibraryManager.LoanService.API.Models.InputModels;
using AmazingLibraryManager.LoanService.API.Services.IServices;

namespace AmazingLibraryManager.LoanService.API.Services
{
    public class BookLoanService : IBookLoanService
    {
        private readonly IUserService _userService;
        private readonly IBookLoanRepository _bookLoanRepository;

        public BookLoanService(IBookLoanRepository bookLoanRepository)
        {
            _bookLoanRepository = bookLoanRepository;
        }

        public async Task<List<BookLoan>> GetAll() 
        {
            var result = await _bookLoanRepository.GetAllAsync();

            if (result is null) throw new NullReferenceException("You don't have loans.");

            return result;
        }

        public async Task<BookLoan> GetByUserId(Guid id) 
        {
            var result = await _bookLoanRepository.GetByUserIdAsync(id);

            if (result is null) throw new NullReferenceException("This loan doesn't exist.");

            return result;
        }

        public async Task AddBookLoan(Guid userId, BookLoanInputModel model) 
        {
            var user = await _userService.GetUserById(userId);

            
        }
    }
}