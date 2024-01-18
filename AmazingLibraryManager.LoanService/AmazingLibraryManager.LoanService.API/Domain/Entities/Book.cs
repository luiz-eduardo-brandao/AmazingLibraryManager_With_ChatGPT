namespace AmazingLibraryManager.LoanService.API.Domain.Entities
{
    public class Book
    {
        public Book(Guid id, string title, string subTitle, string author)
        {
            Id= id;
            Title = title;
            SubTitle = subTitle;
            Author = author;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Author { get; private set; }
    }
}