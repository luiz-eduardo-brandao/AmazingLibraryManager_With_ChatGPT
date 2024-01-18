using AmazingLibraryManager.Users.Core.Events;

namespace AmazingLibraryManager.Users.Core.Entities
{
    public class AggregateRoot : BaseEntity
    {
        public AggregateRoot() : base()
        {
            Events = new List<IEvent>();
        }

        public List<IEvent> Events { get; private set; }

        protected void AddEvent(IEvent @event) 
        {
            Events.Add(@event);
        }
    }
}