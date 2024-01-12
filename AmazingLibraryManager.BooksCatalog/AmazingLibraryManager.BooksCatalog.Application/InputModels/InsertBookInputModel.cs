using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.Application.InputModels
{
    public class InsertBookInputModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

        public Book ToEntity() => new Book(Title, SubTitle, Author, PublishDate); 
    }
}
