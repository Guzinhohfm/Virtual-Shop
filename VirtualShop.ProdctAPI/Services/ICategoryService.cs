using VirtualShop.ProductAPI.DTOs;

namespace VirtualShop.ProductAPI.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();

    Task<IEnumerable<CategoryDTO>> GetCategoriesProduct();

    Task<CategoryDTO> GetCategoryById(int id);

    Task AddCategory(CategoryDTO categoryDTO);

    Task UpdateCategory(CategoryDTO categoryDTO);
    Task DeleteCategory(int id);
}
