using AmazingLibraryManager.Users.Core.Repositories;
using AmazingLibraryManager.Users.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AmazingLibraryManager.Users.Infrastructure
{
    public static class InfrastrucureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddSingleton<IUserRepository, UserRepository>();

            return services;
        }
    }
}