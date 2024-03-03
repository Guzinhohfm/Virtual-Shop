using System.ComponentModel.DataAnnotations;
using VirtualShop.ProductAPI.Models;

namespace VirtualShop.ProductAPI.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
