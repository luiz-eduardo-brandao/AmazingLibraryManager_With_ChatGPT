using AmazingLibraryManager.BooksCatalog.Core.Events;

namespace AmazingLibraryManager.BooksCatalog.Core.Entities
{
    public abstract class AggregateRoot : BaseEntity
    {
        public AggregateRoot() : base()
        {
            Events = new List<IEvent>();
        }

        public List<IEvent> Events { get; private set; }

        public void AddEvent(IEvent @event) 
        {
            Events.Add(@event);
        }
    }
}