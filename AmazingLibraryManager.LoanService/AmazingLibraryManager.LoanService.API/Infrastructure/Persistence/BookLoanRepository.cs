using AmazingLibraryManager.LoanService.API.Domain.Entities;
using AmazingLibraryManager.LoanService.API.Domain.Repositories;

namespace AmazingLibraryManager.LoanService.API.Infrastructure.Persistence
{
    public class BookLoanRepository : IBookLoanRepository
    {
        private readonly List<BookLoan> _loans;

        public BookLoanRepository()
        {
            var book = new Book(Guid.NewGuid(), "Book Test", "Sub Title test", "Luiz Eduardo");
            var book2 = new Book(Guid.NewGuid(), "Book Test 2", "Sub Title test 2", "Luiz Eduardo");
            var book3 = new Book(Guid.NewGuid(), "Book Test 3", "Sub Title test 3", "Luiz Eduardo");

            var books = new List<Book>();
            books.Add(book);
            books.Add(book2);
            books.Add(book3);

            var user = new User(Guid.NewGuid(), "Luiz Eduardo");

            var user2 = new User(Guid.NewGuid(), "Rafael Henrique");

            var bookLoan = new BookLoan(books, user);
            
            var bookLoan2 = new BookLoan(books, user2);

            _loans = new List<BookLoan>();

            _loans.Add(bookLoan);
            _loans.Add(bookLoan2);
        }

        public Task<List<BookLoan>> GetAllAsync() 
        {
            return Task.FromResult(_loans);
        }

        public Task<BookLoan> GetByUserIdAsync(Guid id) 
        {
            var result = _loans.SingleOrDefault(l => l.User.Id == id);

            return Task.FromResult(result);
        }

        public Task<bool> GetLoanByBookAndUserId(Guid userId, Guid bookId) 
        {
            var result = _loans.SingleOrDefault(l => l.User.Id == userId)
                .Books.Any(b => b.Id == bookId);

            return Task.FromResult(result);
        }

        public Task AddBookLoan(BookLoan bookLoan) 
        {
            _loans.Add(bookLoan);

            return Task.CompletedTask;
        }

        public async Task UpdateBookLoan(BookLoan bookLoan) 
        {
            var result = await GetByUserIdAsync(bookLoan.User.Id);

            result.AddBooks(bookLoan.Books);
        }

        public async Task AddBookToLoan(Guid userId, Book book) 
        {
            var result = await GetByUserIdAsync(userId);

            result.AddBook(book);
        }
    }
}