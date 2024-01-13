using AmazingLibraryManager.Users.Core.Entities;

namespace AmazingLibraryManager.Users.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User?>> GetAllAvailible();
        Task<List<User?>> Get();
        Task<User?> GetById(Guid id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(Guid id);
    }
}