using api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers(); // Ensure this is added

// Register Database Context
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference((options, httpContext) =>
{

    options.WithOpenApiRoutePattern("/openapi/v1.json");
    // Object initializer
    options.Title = "Custom API";
    options.ShowSidebar = true;
    options.Theme = ScalarTheme.Saturn;
});
}

// builder.Services.AddDbContext<ApplicationDBContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

// Middleware Setup
app.UseHttpsRedirection();

app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials()
     .SetIsOriginAllowed(origin => true));

// app.UseAuthorization();

app.MapControllers(); 

app.Run();