using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.Core.Events
{
    public class BookUpdated : IEvent
    {
        public BookUpdated(Guid id, string title, string subTitle, string author, DateTime publishDate)
        {
            Id = id;
            Title = title;
            SubTitle = subTitle;
            Author = author;
            PublishDate = publishDate;
        }

        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Author { get; private set; }
        public DateTime PublishDate { get; private set; }
    }
}