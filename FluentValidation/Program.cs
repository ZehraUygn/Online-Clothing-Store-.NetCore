using DataAccess.Database;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.IReq;
using Microsoft.EntityFrameworkCore;
using Business.Mappings;
using Business.Services.Abstract;
using Business.Services.Base;
using DataAccess.Repository.CartReq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped(typeof(IOrderRepository<>), typeof(OrderRepository<>));
builder.Services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
builder.Services.AddScoped(typeof(ICartRepository<>), typeof(CartRepository<>));
builder.Services.AddScoped(typeof(IProductRepository<>), typeof(ProductRepository<>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5433;Database=User;Username=postgres;Password=1234"));

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
