using AmazingLibraryManager.Users.Core.Entities;
using AmazingLibraryManager.Users.Core.Repositories;

namespace AmazingLibraryManager.Users.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
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
            var result = _users.SingleOrDefault(u => u.Id = id);

            return Task.FromResult(result);
        }

        public Task AddUserAsync(User user)
        {
            _users.Add(user);

            return Task.CompletedTask;
        }

        public async Task UpdateUserAsync(User user)
        {
            var result = await GetByIdAsync(user.Id);

            if (result is null) throw new NullReferenceException("There's no User with this id.");

            user.Update(user);
        }
        
        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            if (user is null) throw new NullReferenceException("There's no User with this id.");

            user.Delete();
        }
    }
}