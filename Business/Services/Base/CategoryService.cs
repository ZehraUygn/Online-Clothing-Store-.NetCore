using AutoMapper;
using Business.Models;
using DataAccess.Entities;
using DataAccess.Repository.IReq;

namespace Business.Services.Base
{
    public class CategoryService
    {
        private readonly IUserRepository<Category> categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IUserRepository<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public bool DeleteCategory(int id)
        {
            return categoryRepository.Delete(new Category { Id = id });
        }
        public List<CategoryDto> GetCategory()
        {
            var response = categoryRepository.GetAll();
            return _mapper.Map<List<CategoryDto>>(response);
        }
        public CategoryDto GetCategoryById(int id)
        {
            var response = categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(response);
        }
        public CategoryDto InsertCategory(CategoryDto model)
        {
            var x = _mapper.Map<Category>(model);
            Category response = categoryRepository.Insert(x);

            return _mapper.Map<CategoryDto>(response);
        }
        public  CategoryDto UpdateCategory(UserDto model)
        {
            var categoryEntity = _mapper.Map<Category>(model);
            Category response = categoryRepository.Update(categoryEntity);

            return _mapper.Map<CategoryDto>(response);
        }
    }
}
