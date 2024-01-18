using AmazingLibraryManager.LoanService.API.Domain.Entities;
using Refit;

namespace AmazingLibraryManager.LoanService.API.DataAccess.Interfaces
{
    public interface IUsersClient
    {
        [Get("/availibles")]
        Task<IEnumerable<User>> GetAvailibleUsers();
    }
}