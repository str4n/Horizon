using Horizon.Application;
using Horizon.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication();

builder.AddInfrastructure();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

await app.RunAsync();
