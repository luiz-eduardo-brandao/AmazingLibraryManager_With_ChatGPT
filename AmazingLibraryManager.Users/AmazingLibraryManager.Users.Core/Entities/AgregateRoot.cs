using System.Text.Json;
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

        protected void AddEvent(IEvent @event) 
        {
            var json = JsonSerializer.Serialize(@event);

            Console.WriteLine("AddEvent: " + json);

            Events.Add(@event);
        }
    }
}