using System.ComponentModel.DataAnnotations;
using VirtualShop.ProdctAPI.Models;

namespace VirtualShop.ProdctAPI.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
