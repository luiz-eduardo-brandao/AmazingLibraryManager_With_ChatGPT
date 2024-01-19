using AmazingLibraryManager.LoanService.API.Domain.Entities;
using AmazingLibraryManager.LoanService.API.Domain.Repositories;
using AmazingLibraryManager.LoanService.API.Models.InputModels;
using AmazingLibraryManager.LoanService.API.Services.IServices;

namespace AmazingLibraryManager.LoanService.API.Services
{
    public class BookLoanService : IBookLoanService
    {
        private readonly IUserService _userService;
        private readonly IBookCatalogService _bookCatalogService;
        private readonly IBookLoanRepository _bookLoanRepository;

        public BookLoanService(IBookLoanRepository bookLoanRepository, IUserService userService, IBookCatalogService bookCatalogService)
        {
            _bookLoanRepository = bookLoanRepository;
            _userService = userService;
            _bookCatalogService = bookCatalogService;
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
            if (await VerifyUserAlreadyHasLoan(userId)) 
            {
                foreach (var bookid in model.BookIds) 
                {
                    if (await VerifyBookExistsInUserLoan(userId, bookid)) continue;

                    var newBook = await _bookCatalogService.GetById(bookid);

                    await _bookLoanRepository.AddBookToLoan(userId, newBook);
                }

                return;
            }

            var user = await _userService.GetUserById(userId);

            var bookList = new List<Book>();

            foreach (var bookid in model.BookIds) 
            {
                var book = await _bookCatalogService.GetById(bookid);

                bookList.Add(book);
            }

            var bookLoan = new BookLoan(bookList, user);

            await _bookLoanRepository.AddBookLoan(bookLoan);
        }

        public async Task ReturnBookFromLoan(Guid userId, BookLoanInputModel model) 
        {
            if (!await VerifyUserAlreadyHasLoan(userId)) 
                throw new InvalidOperationException("This User doesn't exist.");

            foreach (var bookid in model.BookIds) 
            {
                if (!await VerifyBookExistsInUserLoan(userId, bookid)) 
                    throw new InvalidOperationException("This Book doesn't exist.");
                    
                await _bookLoanRepository.ReturnBookFromLoan(userId, bookid); 
            }
        }

        private async Task<bool> VerifyUserAlreadyHasLoan(Guid userId) 
        {   
            var result = await _bookLoanRepository.GetByUserIdAsync(userId);

            return result is not null;
        }

        private async Task<bool> VerifyBookExistsInUserLoan(Guid userId, Guid bookId) 
        {
            return await _bookLoanRepository.GetLoanByBookAndUserId(userId, bookId);
        }
    }
}