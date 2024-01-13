using AmazingLibraryManager.Users.Core.Entities;

namespace AmazingLibraryManager.Users.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User?>> GetAvailiblesAsync();
        Task<List<User?>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}