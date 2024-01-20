namespace AmazingLibraryManager.LoanService.API.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}