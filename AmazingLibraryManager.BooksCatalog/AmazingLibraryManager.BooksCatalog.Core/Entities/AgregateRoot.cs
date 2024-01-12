using AmazingLibraryManager.BooksCatalog.Core.Events;

namespace AmazingLibraryManager.BooksCatalog.Core.Entities
{
    public abstract class AgregateRoot
    {
        public AgregateRoot()
        {
            
        }

        public List<IEvent> Events { get; private set; }
    }
}