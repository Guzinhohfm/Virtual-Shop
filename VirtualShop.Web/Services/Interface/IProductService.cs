using VirtualShop.Web.Models;

namespace VirtualShop.Web.Services.Interface;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();

    Task<ProductViewModel> FindProductById(int id);

    Task<ProductViewModel> CreateProduct(ProductViewModel productViewModel);

    Task<ProductViewModel> UpdateProduct(ProductViewModel productViewModel);

    Task<bool> DeleteProductsById(int id);
}
