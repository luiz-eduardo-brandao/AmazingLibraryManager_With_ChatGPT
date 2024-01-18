using AmazingLibraryManager.LoanService.API.DataAccess.RefitConfiguration;
using AmazingLibraryManager.LoanService.API.Domain.Repositories;
using AmazingLibraryManager.LoanService.API.Infrastructure.Persistence;
using AmazingLibraryManager.LoanService.API.Services;
using AmazingLibraryManager.LoanService.API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExternalApiClients(builder.Configuration);

builder.Services.AddSingleton<IBookLoanRepository, BookLoanRepository>();
builder.Services.AddScoped<IBookLoanService, BookLoanService>();
builder.Services.AddScoped<IBookCatalogService, BookCatalogService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
