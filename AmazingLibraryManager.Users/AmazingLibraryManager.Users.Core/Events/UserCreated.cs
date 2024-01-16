namespace AmazingLibraryManager.Users.Core.Events
{
    public class UserCreated : IEvent
    {
        public UserCreated(Guid id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}