using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.Interfaces;
using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using AmazingLibraryManager.BooksCatalog.Core.ValueObjects;

namespace AmazingLibraryManager.BooksCatalog.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<List<Book>> GetAvailibleBooks()
        {
            return await _bookRepository.GetAvailibleBooks();
        }

        public async Task<Book?> GetById(Guid bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);

            VerifyBookExists(book);

            return book;
        }

        public async Task<Book> AddBook(InsertBookInputModel model)
        {
            var book = new Book(model.ToEntity());

            await _bookRepository.AddBookAsync(book);

            return book;
        }

        public async Task<Book> UpdateBook(InsertBookInputModel model)
        {
            var book = new Book(model.Id, model.Title, model.SubTitle, model.Author, model.PublishDate);

            await _bookRepository.UpdateBookAsync(book);

            return book;
        }

        public async Task DeleteBook(Guid id) 
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            VerifyBookExists(book);
            VerifyBookIsLoaned(book);

            if (book.IsDeleted) throw new InvalidOperationException("Book has already deleted.");

            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<List<BookReview>> GetBookReviews(Guid bookId) 
        {
            VerifyBookExists(await _bookRepository.GetBookByIdAsync(bookId));

            var reviews = await _bookRepository.GetBookReviews(bookId);

            if (reviews is null) throw new NullReferenceException("There are not reviews for this book.");

            return reviews;
        }

        public async Task AddBookReview(Guid bookId, AddBookReviewInputModel model) 
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);

            VerifyBookExists(book);

            var rating = VerifyBookRating(model.Rating);

            var bookReview = new BookReview(model.UserId, rating, model.Review);

            await _bookRepository.AddBookReview(bookId, bookReview);
        }

        private BookRating VerifyBookRating(int userRating) 
        {
            BookRating bookRating = userRating switch
            {
                1 => BookRating.Bad,
                2 => BookRating.Unliked,
                3 => BookRating.Medium,
                4 => BookRating.Good,
                5 => BookRating.Amazing
            };

            return bookRating;
        }

        public async Task RegisterBookLoan(Guid id) 
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            VerifyBookExists(book);
            VerifyBookIsLoaned(book);

            await _bookRepository.RegisterBookLoan(id);
        }

        public async Task RegisterBookReturn(Guid id) 
        {
            VerifyBookExists(await _bookRepository.GetBookByIdAsync(id));

            await _bookRepository.RegisterBookReturn(id);
        }

        private void VerifyBookExists(Book book) 
        {
            if (book is null) throw new NullReferenceException("There's no Book with this Id.");
        }

        private void VerifyBookIsLoaned(Book book) 
        {
            if (book.IsLoaned) throw new InvalidOperationException("This Book has already Loaned by other user :( . Please, try another book.");
        }
    }
}
