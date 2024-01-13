namespace AmazingLibraryManager.BooksCatalog.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(Book book)
        {
            Validate(book.Title, book.SubTitle, book.Author, book.PublishDate);

            Id = Guid.NewGuid();
        }

        public Book(string title, string subTitle, string author, DateTime publishDate)
        {
            Validate(title, subTitle, author, publishDate);

            Id = Guid.NewGuid();
        }

        public Book(Guid id, string title, string subTitle, string author, DateTime publishDate)
        {
            Validate(title, subTitle, author, publishDate);

            Id = id;
        }

        public void Update(Book book) 
        {
            Id = book.Id;
            Title = book.Title;
            SubTitle = book.SubTitle;
            Author = book.Author;
            PublishDate = book.PublishDate;
        }

        public void Validate(string title, string subTitle, string author, DateTime publishDate) 
        {
            if (title is null)
                throw new ArgumentException("Invalid book's title.");

            if (title.Length < 5)
                throw new ArgumentException("Book's title is too short. Minimum 5 characters.");

            if (author is null)
                throw new ArgumentException("Invalid Author's name.");

            if (author.Length < 5)
                throw new ArgumentException("Author's name is too short. Minimum 5 characters.");

            Title = title;
            SubTitle = subTitle;
            Author = author;
            PublishDate = publishDate;
        }

        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Author { get; private set; }
        public DateTime PublishDate { get; private set; }
    }
}
