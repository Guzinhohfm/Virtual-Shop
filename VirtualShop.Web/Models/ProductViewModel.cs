﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualShop.Web.Models;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public long stock { get; set; }

    public string? ImageURL { get; set; }

    public string? CategoryName { get; set; }

    public int CategoryId { get; set; }

}