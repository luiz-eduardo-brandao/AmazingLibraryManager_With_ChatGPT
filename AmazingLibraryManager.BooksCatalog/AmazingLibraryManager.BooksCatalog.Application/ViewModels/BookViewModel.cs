using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.ValueObjects;

namespace AmazingLibraryManager.BooksCatalog.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(Book book)
        {
            Id = book.Id;
            CreatedAt = book.CreatedAt;
            IsDeleted = book.IsDeleted;
            Title = book.Title;
            SubTitle = book.SubTitle;
            Author = book.Author;
            IsLoaned = book.IsLoaned;
            PublishDate = book.PublishDate;
            Reviews = book.Reviews;
        }

        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Author { get; private set; }
        public bool IsLoaned { get; private set; }
        public DateTime PublishDate { get; private set; }
        public List<BookReview> Reviews { get; set; }
    }
}