namespace AmazingLibraryManager.Users.Application.ViewModel
{
    public class UserViewModel
    {        
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}