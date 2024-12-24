using Business.Models;
using Business.Services.Base;

namespace Business.Services.Abstract
{
    public interface IProductService 
    {
        List<ProductDto> GetProducts();
        ProductDto GetProductById(int id);
        ProductDto InsertProduct(ProductDto model);
        ProductDto UpdateProduct(ProductDto model);
        bool DeleteProduct(int id);
    }
}
