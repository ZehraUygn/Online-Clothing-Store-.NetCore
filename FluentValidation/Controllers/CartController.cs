using Business.Models;
using Business.Services.Abstract;
using Business.Validator;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{      
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
            public CartController(ICartService cartService)
            {
                _cartService = cartService;
            }
            [HttpGet]
            public async Task<ActionResult<CartDto>> GetCartByCustomerId(int userId)
            {
                var cart = await _cartService.GetCartByCustomerIdAsync(userId);
                if (cart == null) return NotFound();
                return Ok(cart);
            }
            [HttpPost]
            public async Task<ActionResult> AddCartItem(int userId, CartItemDto item)
            {
                var validator = new CartItemValidator();
                var result = validator.Validate(item);
                if (result.IsValid)
                {
                    await _cartService.AddCartItemAsync(userId, item.ProductId, item.Size, item.Price, item.Color, item.Quantity);

                }
                return Ok();
            }
            [HttpPut]
            public async Task<ActionResult> UpdateCartItem(int cartItemId, int quantity)
            {
                await _cartService.UpdateCartItemAsync(cartItemId, quantity);
                return Ok();
            }
            [HttpDelete]
            public async Task<ActionResult> DeleteCartItem(int cartItemId)
            {
                await _cartService.DeleteCartItemAsync(cartItemId);
                return NoContent();
            }
            [HttpDelete]
            public async Task<ActionResult> ClearCart(int userId)
            {
                await _cartService.ClearCartAsync(userId);
                return NoContent();
            }
    }
}
