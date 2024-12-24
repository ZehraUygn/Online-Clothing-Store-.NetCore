using System;
using System.Collections.Generic;
using DataAccess.Database;
using DataAccess.Entities;
using DataAccess.Repository.CartReq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CartRepository<TEntity> : ICartRepository<TEntity> where TEntity : class
    {
        private readonly UserContext _context;
        public CartRepository(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Cart> GetCartByCustomerIdAsync(int userId)
        {
            if (_context == null)
                throw new Exception("Database context is null.");
            if (_context.Carts == null)
                throw new Exception("Carts DbSet is null.");

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return cart;
        }

        public async Task AddCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }
        public async Task AddCartItemAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCartItemAsync(int cartItemsId)
        {
            var item = await _context.CartItems.FindAsync(cartItemsId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(int userId)
        {
            var cart = await GetCartByCustomerIdAsync(userId);
            if (cart != null)
            {
                _context.CartItems.RemoveRange(cart.CartItems);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(ci => ci.Id == cartItemId);
        }


    }
}