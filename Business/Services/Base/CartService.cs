using AutoMapper;
using Business.Models;
using Business.Services.Abstract;
using DataAccess.Entities;
using DataAccess.Repository.CartReq;

namespace Business.Services.Base
{
    public class CartService : ICartService
    {
        private readonly ICartRepository<Cart> cartRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository<Cart> cartRepository, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartByCustomerIdAsync(int userId)
        {
            var cart = await cartRepository.GetCartByCustomerIdAsync(userId);
            if (cart == null) return null;

            return _mapper.Map<CartDto>(cart);
        }

        public async Task AddCartItemAsync(int userId, int productId, string size, decimal price, string color, int quantity) //v1
        {
            var cart = await this.cartRepository.GetCartByCustomerIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };//nu
                await this.cartRepository.AddCartAsync(cart);
            }
            var existingItem = cart.CartItems.FirstOrDefault(i => i.ProductId == productId && i.Size == size && i.Price == price && i.Color == color);
            if (existingItem is not null)
            {
                existingItem.Quantity += quantity;
                await this.cartRepository.UpdateCartItemAsync(existingItem);
            }
            else
            {
                var newItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Size = size,
                    Price = price,
                    Color = color,
                    Quantity = quantity
                };
                await this.cartRepository.AddCartItemAsync(newItem);
            }
        }

        public async Task UpdateCartItemAsync(int cartItemId, int quantity)
        {
            var cartItem = await this.cartRepository.GetCartItemByIdAsync(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                await cartRepository.UpdateCartItemAsync(cartItem);
            }
            else
            {
                throw new Exception("CartItem not found");
            }
        }
        public async Task DeleteCartItemAsync(int cartItemId)
        {
            await this.cartRepository.DeleteCartItemAsync(cartItemId);
        }

        public async Task ClearCartAsync(int customerId)
        {

            await this.cartRepository.ClearCartAsync(customerId);
        }
    }
}

