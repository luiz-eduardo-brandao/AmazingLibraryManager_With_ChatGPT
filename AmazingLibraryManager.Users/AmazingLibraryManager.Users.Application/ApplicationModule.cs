using AmazingLibraryManager.Users.Application.Interfaces;
using AmazingLibraryManager.Users.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AmazingLibraryManager.Users.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}