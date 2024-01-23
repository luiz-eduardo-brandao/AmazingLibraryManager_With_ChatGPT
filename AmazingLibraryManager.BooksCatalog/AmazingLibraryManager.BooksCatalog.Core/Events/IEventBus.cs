namespace AmazingLibraryManager.BooksCatalog.Core.Events
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}