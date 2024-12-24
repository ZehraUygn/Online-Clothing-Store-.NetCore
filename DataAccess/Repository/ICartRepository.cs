using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repository.CartReq
{
    public interface ICartRepository<TEntity> where TEntity : class
    {
        Task<Cart> GetCartByCustomerIdAsync(int userId);
        Task AddCartAsync(Cart cart);
        Task AddCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task DeleteCartItemAsync(int cartItem);
        Task ClearCartAsync(int userId);
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
    }
}
