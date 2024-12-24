using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using DataAccess.Entities;

namespace Business.Services.Abstract
{
    public interface ICartService
    {
        Task<CartDto> GetCartByCustomerIdAsync(int customerId);
        Task AddCartItemAsync(int customerId, int productId, string size, decimal price, string color, int quantity);
        Task UpdateCartItemAsync(int cartItemId, int quantity);
        Task DeleteCartItemAsync(int cartItemId);
        Task ClearCartAsync(int customerId);
    }
}