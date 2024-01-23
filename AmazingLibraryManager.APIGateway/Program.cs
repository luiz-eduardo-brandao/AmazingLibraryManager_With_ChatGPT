using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers();

builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOcelot();

app.Run();
