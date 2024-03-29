﻿using VirtualShop.ProductAPI.Models;

namespace VirtualShop.ProductAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();

    Task<Product> GetProductById(int id);
    Task<Product> Create(Product Product);
    Task<Product> Update(Product Product);

    Task<Product> Delete(int id);
}
