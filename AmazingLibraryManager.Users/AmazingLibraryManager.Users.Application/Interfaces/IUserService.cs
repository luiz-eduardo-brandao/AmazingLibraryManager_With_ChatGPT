using System.Data;
using AmazingLibraryManager.Users.Application.InputModels;
using AmazingLibraryManager.Users.Core.Entities;

namespace AmazingLibraryManager.Users.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User?>> GetAllAvailible();
        Task<List<User?>> Get();
        Task<User?> GetById(Guid id);
        Task<User> AddUser(AddUserInputModel model);
        Task<User> UpdateUser(UpdateUserInputModel model);
        Task DeleteUser(Guid id);
    }
}