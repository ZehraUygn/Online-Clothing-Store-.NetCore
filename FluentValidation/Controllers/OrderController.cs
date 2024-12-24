using Business.Models;
using Business.Services.Abstract;
using Business.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetOrderByCustomerId(int userId)
        {
            var order = await _orderService.GetOrderByCustomerIdAsync(userId);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(int userId)
        {
            await _orderService.AddOrderAsync(userId);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int userId)
        {
            await _orderService.DeleteOrderAsync(userId);
            return NoContent();
        }



    }
}
