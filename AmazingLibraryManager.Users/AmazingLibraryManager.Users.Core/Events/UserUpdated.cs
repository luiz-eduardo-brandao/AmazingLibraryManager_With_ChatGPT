namespace AmazingLibraryManager.Users.Core.Events
{
    public class UserUpdated : IEvent
    {
        public UserUpdated(Guid id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}