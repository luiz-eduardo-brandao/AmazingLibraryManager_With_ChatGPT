using AmazingLibraryManager.LoanService.API.DataAccess.Interfaces;
using Refit;

namespace AmazingLibraryManager.LoanService.API.DataAccess.RefitConfiguration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExternalApiClients(this IServiceCollection services, IConfiguration configuration) 
        {
            var bookCatalogApiUrl = configuration["ServicesUrls:BookCatalog"];
            var usersApiUrl = configuration["ServicesUrls:Users"];

            services
                .AddRefitClient<IBookCatalogClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(bookCatalogApiUrl));

            services
                .AddRefitClient<IUsersClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(usersApiUrl));

            return services;
        }
    }
}