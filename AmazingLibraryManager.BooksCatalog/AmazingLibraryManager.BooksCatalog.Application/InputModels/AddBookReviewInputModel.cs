namespace AmazingLibraryManager.BooksCatalog.Application.InputModels
{
    public class AddBookReviewInputModel
    {
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}