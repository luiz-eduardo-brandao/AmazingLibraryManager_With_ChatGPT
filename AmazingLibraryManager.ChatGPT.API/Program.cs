using AmazingLibraryManager.ChatGPT.API.Extensions;
using AmazingLibraryManager.ChatGPT.API.Infrastructure.Interfaces;
using AmazingLibraryManager.ChatGPT.API.Infrastructure.Persistence;
using AmazingLibraryManager.ChatGPT.API.Services;
using AmazingLibraryManager.ChatGPT.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog(builder.Configuration, "App name to describe microsservices");
builder.AddChatGpt();

builder.Services.AddSingleton<IChatGptRepository, ChatGptRepository>();
builder.Services.AddScoped<IChatGptService, ChatGptService>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwagger(builder.Configuration, "AmazingLibraryManager.ChatGPT.API");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc("AmazingLibraryManager.ChatGPT.API");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
