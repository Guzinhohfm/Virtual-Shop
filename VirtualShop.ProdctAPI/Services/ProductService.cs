using AutoMapper;
using VirtualShop.ProductAPI.DTOs;
using VirtualShop.ProductAPI.Models;
using VirtualShop.ProductAPI.Repositories;

namespace VirtualShop.ProductAPI.Services;

public class ProductService: IProductService
{
    private IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }


    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();

        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productEntity = await _productRepository.GetProductById(id);

        return _mapper.Map<ProductDTO>(productEntity);
    }

    public async Task AddProduct(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Create(productEntity);
        productDTO.Id = productEntity.Id;
    }

    public async Task UpdateProduct(ProductDTO productDTO)
    {
        var productEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Update(productEntity);
    }

 

    public async Task DeleteProduct(int id)
    {
        var productyEntity = _productRepository.GetProductById(id).Result;
        await _productRepository.Delete(productyEntity.Id);
    }

  
    
}
