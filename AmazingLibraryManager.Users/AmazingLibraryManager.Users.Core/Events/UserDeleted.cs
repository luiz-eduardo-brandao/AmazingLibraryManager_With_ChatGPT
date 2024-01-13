namespace AmazingLibraryManager.Users.Core.Events
{
    public class UserDeleted : IEvent
    {
        public UserDeleted(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}