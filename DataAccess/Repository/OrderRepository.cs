using DataAccess.Database;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class OrderRepository<TEntity> : IOrderRepository<TEntity> where TEntity : class
    {
        private readonly UserContext _context;

        public OrderRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByCustomerIdAsync(int userID)
        {
            if (_context == null)
                throw new Exception("Database context is null.");
            if (_context.Orders == null)
                throw new Exception("Orders DbSet is null.");

            var order = await _context.Orders
            .Include(c => c.Order_details).Include(k=>k.User)
                .FirstOrDefaultAsync(c => c.UserId == userID);
            return order;
        }
        public async Task AddOrderAsync(Cart cart)
        {
            decimal total_price = cart.CartItems.Sum(ci => ci.Quantity * ci.Price);
            var order = new Order
            {
                UserId = cart.UserId,
                CartId = cart.Id,
                TotalPrice = total_price,
                Order_details = cart.CartItems.Select(ci => new OrderDetails
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Size = ci.Size,
                    Color = ci.Color
                }).ToList()
            };
            
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int userId)
        {
            var item = await _context.Orders.FindAsync(userId);
            if (item != null)
            {
                _context.Orders.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}