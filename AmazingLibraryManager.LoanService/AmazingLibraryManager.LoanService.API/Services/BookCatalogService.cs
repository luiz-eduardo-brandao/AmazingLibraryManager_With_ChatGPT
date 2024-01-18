using AmazingLibraryManager.LoanService.API.DataAccess.Interfaces;
using AmazingLibraryManager.LoanService.API.Domain.Entities;
using AmazingLibraryManager.LoanService.API.Services.IServices;
using Refit;

namespace AmazingLibraryManager.LoanService.API.Services
{
    public class BookCatalogService : IBookCatalogService
    {
        private readonly IBookCatalogClient _client;

        public BookCatalogService(IBookCatalogClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Book>> GetAvailibleBooks() 
        {
            try 
            {
                var result = await _client.GetAvailibleBooks();

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

        public async Task<Book> GetById(Guid id) 
        {
            try 
            {
                var result = await _client.GetById(id);

                if (result is null) throw new NullReferenceException("There Book doesn't exist.");

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