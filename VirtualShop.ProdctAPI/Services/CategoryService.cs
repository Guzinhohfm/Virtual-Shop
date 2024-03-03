using AutoMapper;
using VirtualShop.ProductAPI.DTOs;
using VirtualShop.ProductAPI.Models;
using VirtualShop.ProductAPI.Repositories;

namespace VirtualShop.ProductAPI.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity); 
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProduct()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesProducts();

        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoryEntity = await _categoryRepository.GetCategoryById(id);

        return _mapper.Map<CategoryDTO>(categoryEntity);

    }
    public async Task AddCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Create(categoryEntity);
        categoryDTO.Id = categoryEntity.Id;
    }

    public async Task UpdateCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Update(categoryEntity);
    }

    public async Task DeleteCategory(int id)
    {
        var categoryEntity = _categoryRepository.GetCategoryById(id).Result;
        await _categoryRepository.Delete(categoryEntity.Id);
    }

    
}
