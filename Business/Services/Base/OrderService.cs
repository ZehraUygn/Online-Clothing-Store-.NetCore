using AutoMapper;
using Business.Models;
using Business.Services.Abstract;
using DataAccess.Entities;
using DataAccess.Repository;
using DataAccess.Repository.CartReq;

namespace Business.Services.Base
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository<Order> orderRepository;
        private readonly ICartRepository<Cart> cartRepository; 
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository<Order> orderRepository, IMapper mapper, ICartRepository<Cart> cartRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task AddOrderAsync(int userId)
        {
            var cart = await cartRepository.GetCartByCustomerIdAsync(userId);

            if (cart == null || !cart.CartItems.Any())
                throw new Exception("Cart is empty or does not exist");

            await orderRepository.AddOrderAsync(cart);
        }
        public async Task DeleteOrderAsync(int userId)
        {
            await orderRepository.DeleteOrderAsync(userId);
        }
        public async Task<OrderDto> GetOrderByCustomerIdAsync(int userId)
        {
            var order = await orderRepository.GetOrderByCustomerIdAsync(userId);
            if (order == null) return null;

            return _mapper.Map<OrderDto>(order);
        }
    }
}