using AmazingLibraryManager.LoanService.API.Domain.Entities;

namespace AmazingLibraryManager.LoanService.API.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAvailibleUsers();
    }
}