using Microsoft.EntityFrameworkCore;
using Robot.API;
using Robot.Repository.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FactoryManagementContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Robot"))
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
});


builder.Services.AddWebAPIService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
