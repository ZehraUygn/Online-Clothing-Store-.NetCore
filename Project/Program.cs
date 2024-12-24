using Microsoft.EntityFrameworkCore;
using Project.Model;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Project.Validator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("User"));
builder.Services.AddControllers().AddFluentValidation(fv =>
    fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());

builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5433;Database=User;Username=postgres;Password=1234"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
