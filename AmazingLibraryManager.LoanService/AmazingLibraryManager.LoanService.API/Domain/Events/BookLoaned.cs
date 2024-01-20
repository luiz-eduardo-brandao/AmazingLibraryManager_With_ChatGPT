namespace AmazingLibraryManager.LoanService.API.Domain.Events
{
    public class BookLoaned : IEvent
    {
        public Guid UserId { get; set; }
        public List<Guid> BookIds { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}