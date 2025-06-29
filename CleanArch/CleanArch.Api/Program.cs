using CleanArch.Infrastructure.Data.Context;
using CleanArch.Infrastructure.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//UniversityDb
var universityDbConnectionString = builder.Configuration.GetConnectionString("UniversityDbConnection") ?? throw new InvalidOperationException("Connection string 'UniversityDbConnection' not found.");
builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(universityDbConnectionString));

//
DependencyContainer.RegisterServices(builder.Services);

builder.Services.AddSwaggerGen(cfg => 
{
    cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "University Api", Version = "v1" });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "University Api V1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
