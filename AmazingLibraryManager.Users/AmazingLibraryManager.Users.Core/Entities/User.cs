using AmazingLibraryManager.Users.Core.Events;

namespace AmazingLibraryManager.Users.Core.Entities
{
    public class User : AgregateRoot
    {
        public User(string name, string email, string phoneNumber) : base()
        {
            Validate(name, email, phoneNumber);

            AddEvent(new UserCreated(Id, Name, Email, PhoneNumber));
        }

        public User(Guid id, string name, string email, string phoneNumber) : base()
        {
            Validate(name, email, phoneNumber);

            Id = id;

            AddEvent(new UserUpdated(Id, Name, Email, PhoneNumber));
        }

        public void Update(User user) 
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }

        public void Delete()
        {
            IsDeleted = true;

            AddEvent(new UserDeleted(Id));
        }

        public void Validate(string name, string email, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("Name is required.");

            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidOperationException("Email is required.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new InvalidOperationException("Phone number is required.");
            
            if (name.Length <= 2)
                throw new InvalidOperationException("Name is too short. Minimum 3 characters.");

            if (phoneNumber.Length < 12)
                throw new InvalidOperationException("Phone number is invalid. Please put a correct number to register.");

            if (!email.Contains("@") || !email.Contains(".com"))
                throw new InvalidOperationException("Email is invalid. Please put a correct number to register.");
            
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}