namespace AmazingLibraryManager.BooksCatalog.Core.Events
{
    public class BookCreated
    {
        public BookCreated(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
    }
}
