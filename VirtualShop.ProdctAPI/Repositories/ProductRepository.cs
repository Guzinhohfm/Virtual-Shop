using Microsoft.EntityFrameworkCore;
using VirtualShop.ProdctAPI.Context;
using VirtualShop.ProdctAPI.Models;

namespace VirtualShop.ProdctAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDBContext _dbContext;

    public ProductRepository(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _dbContext.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> Create(Product Product)
    {
        _dbContext.Products.Add(Product);
        await _dbContext.SaveChangesAsync();
        return Product;
    }

    public async Task<Product> Update(Product Product)
    {
        _dbContext.Entry(Product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return Product;
    }

    public async Task<Product> Delete(int id)
    {

        var Product = await GetProductById(id);
        _dbContext.Products.Remove(Product);
        await _dbContext.SaveChangesAsync();
        return Product;


    }
}
