using Microsoft.EntityFrameworkCore;
using LocationsAvailability.Infrastructure;
using LocationsAvailability.Utilities;
using LocationsAvailability.Queries.Interfaces;
using LocationsAvailability.Queries;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonCoverter());
    });

// Check if we are naming properly the database
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseInMemoryDatabase("LocationsDatabase"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Dependency Injection
builder.Services.AddScoped<ILocationQueries, LocationQueries>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();

    DbInitializer.Initialize(dbContext);

    // Dispose of the DbContext after the scope ends
    using var serviceScope = scope.ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
    dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
