using AmazingLibraryManager.LoanService.API.DataAccess.Interfaces;
using AmazingLibraryManager.LoanService.API.Domain.Entities;
using AmazingLibraryManager.LoanService.API.Services.IServices;
using Refit;

namespace AmazingLibraryManager.LoanService.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersClient _client;

        public UserService(IUsersClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> GetAvailibleUsers() 
        {
            try 
            {
                var result = await _client.GetAvailibleUsers();

                if (result is null) throw new NullReferenceException("There aren't availible books.");

                return result;
            }
            catch (ApiException ex) 
            {
                var content = ex.GetContentAsAsync<Dictionary<string, string>>();
                var message = content.Result?.FirstOrDefault(pair => pair.Key == "message").Value;

                throw new InvalidOperationException(message);
            }
        }
    }
}