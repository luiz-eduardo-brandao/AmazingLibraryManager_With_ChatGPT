using AmazingLibraryManager.Users.Application.InputModels;
using AmazingLibraryManager.Users.Application.Interfaces;
using AmazingLibraryManager.Users.Application.MappingExtensions;
using AmazingLibraryManager.Users.Core.Entities;
using AmazingLibraryManager.Users.Core.Repositories;

namespace AmazingLibraryManager.Users.Application.Services
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User?>> GetAllAvailible()
        {   
            return await _userRepository.GetAvailiblesAsync();
        }

        public async Task<List<User?>> Get()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetById(Guid id)
        {
            var result = await _userRepository.GetByIdAsync(id);

            if (result is null) throw new NullReferenceException("This User doesn't exist.");

            return result;
        }

        public async Task<User> AddUser(AddUserInputModel model)
        {
            var user = model.ToUser();

            // var user = new User(model.Name, model.Email, model.PhoneNumber); 

            await _userRepository.AddUserAsync(user);

            return user;
        }

        public async Task<User> UpdateUser(UpdateUserInputModel model)
        {
            var _ = await GetById(model.Id);

            var user = new User(model.Id, model.Name, model.Email, model.PhoneNumber);

            await _userRepository.UpdateUserAsync(user);

            return user;
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await GetById(id);

            if (user.IsDeleted) throw new InvalidOperationException("User has already been deleted.");

            await _userRepository.DeleteUserAsync(id);
        }
    }
}