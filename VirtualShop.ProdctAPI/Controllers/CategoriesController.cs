using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductAPI.DTOs;
using VirtualShop.ProductAPI.Services;

namespace VirtualShop.ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
   
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var categoriesDTO =  _categoryService.GetCategories();
        if (categoriesDTO == null)
            return NotFound("Categories not found");

        return Ok(categoriesDTO);
        
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
    {
        var categoriesDTO = _categoryService.GetCategoriesProduct();
        if (categoriesDTO == null)
            return NotFound("Categories not found");

        return Ok(categoriesDTO);

    }

    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetById(int id)
    {
        var categoriesDTO = _categoryService.GetCategoryById(id);
        if (categoriesDTO == null)
            return NotFound("Categories not found");

        return Ok(categoriesDTO);

    }


    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO == null)
            return NotFound("Invalid data");

        await _categoryService.AddCategory(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);

    }

    [HttpPut("{id}")]

    public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.Id)
            return BadRequest();

        if (categoryDTO.Id == null)
            return BadRequest();

        await _categoryService.UpdateCategory(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);

        if (categoryDTO == null)
            return NotFound("Category not found");

        await _categoryService.DeleteCategory(categoryDTO.Id);

        return Ok(categoryDTO);
    }

}
