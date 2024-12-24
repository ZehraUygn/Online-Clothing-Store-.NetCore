using Business.Models;
using Business.Services.Abstract;
using Business.Services.Base;
using Business.Validator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Octopus.Client.Validation;
using Project.Validator;

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

            var validator = new ProductValidator();
            var result = validator.Validate(model);

            if (result.IsValid)
            {
                return _productService.InsertProduct(model);
            }
            return null;
            
         }
        [HttpPost]
        public ProductDto UpdateProduct(ProductDto model)
        {
            var validator = new ProductValidator();
            var result = validator.Validate(model);

            if (result.IsValid)
            {
               return _productService.UpdateProduct(model);
            }
            return null;
        }
    }
}
