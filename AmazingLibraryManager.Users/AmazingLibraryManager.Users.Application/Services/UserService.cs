using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingLibraryManager.Users.Application.Interfaces;

namespace AmazingLibraryManager.Users.Application.Services
{
    public class UserService : IUserService 
    {
        Task<List<User?>> GetAllAvailible(){}
        Task<List<User?>> Get(){}
        Task<User?> GetById(Guid id){}
        Task<User> AddUser(User user){}
        Task<User> UpdateUser(User user){}
        Task DeleteUser(Guid id){}
    }
}