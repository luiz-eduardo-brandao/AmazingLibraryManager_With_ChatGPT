using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.Core.Events
{
    public class BookUpdated : IEvent
    {
        public BookUpdated(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            SubTitle = book.SubTitle;
            Author = book.Author;
            PublishDate = book.PublishDate;
        }

        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Author { get; private set; }
        public DateTime PublishDate { get; private set; }
    }
}