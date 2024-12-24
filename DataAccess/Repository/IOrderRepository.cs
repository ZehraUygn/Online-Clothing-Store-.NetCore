using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public interface IOrderRepository<TEntity> where TEntity : class
    {
        Task<Order> GetOrderByCustomerIdAsync(int userId);
        Task AddOrderAsync(Cart cart);
        Task DeleteOrderAsync(int userId);
    }
}