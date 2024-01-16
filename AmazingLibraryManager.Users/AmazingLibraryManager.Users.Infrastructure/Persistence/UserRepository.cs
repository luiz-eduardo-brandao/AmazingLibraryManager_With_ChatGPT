using AmazingLibraryManager.Users.Core.Entities;
using AmazingLibraryManager.Users.Core.Repositories;

namespace AmazingLibraryManager.Users.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User> 
            {
                new User(Guid.NewGuid(), "Admin", "admin@localhost.com", "122345567891"),
                new User(Guid.NewGuid(), "User", "user@localhost.com", "198765432112")
            };
        }

        public Task<List<User?>> GetAvailiblesAsync()
        {
            var result = _users.Where(u => !u.IsDeleted).ToList();

            return Task.FromResult(result);
        }
        
        public Task<List<User?>> GetAllAsync() 
        {    
            return Task.FromResult(_users);
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            var result = _users.SingleOrDefault(u => u.Id == id);

            return Task.FromResult(result);
        }

        public Task AddUserAsync(User user)
        {
            _users.Add(user);

            return Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            var result = _users.SingleOrDefault(u => u.Id == user.Id);

            result.Update(user);
        }
        
        public async Task DeleteUserAsync(Guid id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);

            user.Delete();
        }
    }
}