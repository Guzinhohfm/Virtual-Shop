using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductAPI.Context;
using VirtualShop.ProductAPI.Models;

namespace VirtualShop.ProductAPI.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDBContext _dbContext;

    public CategoryRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
       return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _dbContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        return await _dbContext.Categories.Include(c => c.Products).ToListAsync();
    }

    public async Task<Category> Create(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _dbContext.Entry(category).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {

        var category = await GetCategoryById(id);
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return category;
     
      
    }


}
