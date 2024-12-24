using Business.Models;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet]
        public bool DeleteProduct(int productId) => _productService.DeleteProduct(productId);
        [HttpPost]
        public ProductDto InsertProduct(ProductDto model) {           
            return _productService.InsertProduct(model);
         }
        [HttpPost]
        public ProductDto UpdateProduct(ProductDto model)
        {
                return _productService.UpdateProduct(model);
        }
    }
}
