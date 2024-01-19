namespace AmazingLibraryManager.LoanService.API.Domain.Entities
{
    public class BookLoan
    {
        public BookLoan(List<Book> books, User user)
        {
            Id = Guid.NewGuid();
            Books = books;
            User = user;
            LoanDate = DateTime.Now;
            ReturnDate = DateTime.Now.AddDays(7);
            IsEnabled = true;
        }

        public void AddBook(Book book) 
        {
            Books.Add(book);
        }

        public void AddBooks(List<Book> books) 
        {
            foreach (var book in books) 
            {
                Books.Add(book);
            }
        }

        public Guid Id { get; private set; }
        public List<Book> Books { get; private set; }
        public User User { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public bool IsEnabled { get; private set; }
    }
}