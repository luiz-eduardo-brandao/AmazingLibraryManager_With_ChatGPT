using AmazingLibraryManager.LoanService.API.Domain.Events;

namespace AmazingLibraryManager.LoanService.API.Domain.Entities
{
    public class AggregateRoot
    {
        public AggregateRoot()
        {
            Events = new List<IEvent>();
        }

        public void AddEvents(IEvent @event) 
        {
            Events.Add(@event);
        }

        public List<IEvent> Events { get; set; }
    }
}