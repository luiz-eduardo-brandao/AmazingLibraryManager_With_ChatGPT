using AmazingLibraryManager.LoanService.API.Domain.Entities;
using Refit;

namespace AmazingLibraryManager.LoanService.API.DataAccess.Interfaces
{
    public interface IUsersClient
    {
        [Get("/user/availibles")]
        Task<IEnumerable<User>> GetAvailibleUsers();

        [Get("/user/{id}")]
        Task<ApiResponse<User>> GetById(Guid id);
    }
}