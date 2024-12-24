using Business.Models;
using Business.Services.Base;

namespace Business.Services.Abstract
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategory();
        CategoryDto GetCategoryById(int id);
        CategoryDto InsertCategory(CategoryDto model);
        CategoryDto UpdateCategory(CategoryDto model);
        bool DeleteCategory(int id);
    }
}
