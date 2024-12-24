using AutoMapper;
using Business.Models;
using Business.Services.Abstract;
using DataAccess.Entities;
using DataAccess.Repository;

namespace Business.Services.Base
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository<Product> productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            _mapper = mapper;
        }
        public bool DeleteProduct(int id)
        {
            return productRepository.Delete(new Product { Id = id });
        }
        public List<ProductDto> GetProducts()
        {
            var response = productRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(response);
        }
        public ProductDto GetProductById(int id)
        {
            var response = productRepository.GetById(id);
            return _mapper.Map<ProductDto>(response);
        }
        public ProductDto InsertProduct(ProductDto model)
        {
            var x = _mapper.Map<Product>(model);
            Product response = productRepository.Insert(x);

            return _mapper.Map<ProductDto>(response);
        }
        public ProductDto UpdateProduct(ProductDto model)
        {
            var productEntity = _mapper.Map<Product>(model);
            Product response = productRepository.Update(productEntity);

            return _mapper.Map<ProductDto>(response);
        }
    }
}
