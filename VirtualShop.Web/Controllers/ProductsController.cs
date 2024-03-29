﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualShop.Web.Models;
using VirtualShop.Web.Services.Interface;

namespace VirtualShop.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductsController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _productService.GetAllProducts();
        if (result == null)
        {
            return View("Error");
        }

        return View(result);



    }

    [HttpGet]

    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.Id = new SelectList(await
            _categoryService.GetAllCategories(), "Id", "Name");

        return View();
    }

    [HttpPost]

    public async Task<IActionResult> CreateProduct(ProductViewModel productVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _productService.CreateProduct(productVM);

            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            ViewBag.Id = new SelectList(await
           _categoryService.GetAllCategories(), "Id", "Name");
        }

        return View(productVM);
            
    }

}
