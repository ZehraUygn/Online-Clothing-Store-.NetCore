using Business.Models;
using DataAccess.Entities;

namespace Business.Services.Abstract
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByCustomerIdAsync(int userId);
        Task AddOrderAsync(int userId);
        Task DeleteOrderAsync(int orderId);
    }
}
