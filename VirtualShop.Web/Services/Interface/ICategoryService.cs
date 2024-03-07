using VirtualShop.Web.Models;

namespace VirtualShop.Web.Services.Interface;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategories();
}
