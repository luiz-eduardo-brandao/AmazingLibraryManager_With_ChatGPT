using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using AmazingLibraryManager.BooksCatalog.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AmazingLibraryManager.BooksCatalog.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();

            return services;
        }
    }
}
