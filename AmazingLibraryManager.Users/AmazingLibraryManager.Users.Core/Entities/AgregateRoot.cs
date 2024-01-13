using AmazingLibraryManager.Users.Core.Events;

namespace AmazingLibraryManager.Users.Core.Entities
{
    public class AgregateRoot : BaseEntity
    {
        public AgregateRoot() : base()
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