namespace AmazingLibraryManager.LoanService.API.Domain.Entities
{
    public class User
    {
        public User(Guid id, string name)
        {
            Id= id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}