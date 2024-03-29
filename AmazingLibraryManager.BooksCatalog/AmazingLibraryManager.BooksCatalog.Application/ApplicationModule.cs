﻿using AmazingLibraryManager.BooksCatalog.Application.Consumers;
using AmazingLibraryManager.BooksCatalog.Application.Interfaces;
using AmazingLibraryManager.BooksCatalog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AmazingLibraryManager.BooksCatalog.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHostedService<BookLoanedConsumer>(); 
            services.AddHostedService<BookReturnedConsumer>(); 
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
