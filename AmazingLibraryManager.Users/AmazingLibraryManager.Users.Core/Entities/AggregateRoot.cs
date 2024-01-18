using System.Text.Json;
using AmazingLibraryManager.Users.Core.Events;

namespace AmazingLibraryManager.Users.Core.Entities
{
    public class AggregateRoot : BaseEntity
    {
        public AggregateRoot() : base()
        {
            // Events = new List<IEvent>();
            Events = new List<string>();
        }

        public List<string> Events { get; private set; }

        protected void AddEvent(string @event) 
        {
            var json = JsonSerializer.Serialize(@event);

            Console.WriteLine("AddEvent: " + json);

            Events.Add(@event);
        }
    }
}