using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using AmazingLibraryManager.BooksCatalog.Infrastructure.EventBus;
using AmazingLibraryManager.BooksCatalog.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using AmazingLibraryManager.BooksCatalog.Core.Events;

namespace AmazingLibraryManager.BooksCatalog.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddScoped<IEventBus, RabbitMqService>();

            return services;
        }
    }
}
