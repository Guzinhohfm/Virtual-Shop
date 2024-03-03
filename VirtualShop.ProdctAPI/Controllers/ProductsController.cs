using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductAPI.DTOs;
using VirtualShop.ProductAPI.Services;

namespace VirtualShop.ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var productDTO = await _productService.GetProducts();
        if (productDTO == null)
            return NotFound("Product not found");

        return Ok(productDTO);

    }

    [HttpGet("{id}", Name = "GetProducts")]

    public async Task<ActionResult<ProductDTO>> GetProductById(int id)
    {
        var productDTO = await _productService.GetProductById(id);

        if (productDTO == null)
            return NotFound("Product not found");

        return Ok(productDTO);
    }

    [HttpPost]

    public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null)
            return BadRequest("Invalid data");

        await _productService.AddProduct(productDTO);

        return new CreatedAtRouteResult("GetProduct", 
            new {id = productDTO.Id}, productDTO);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
    {
        if (id != productDTO.Id)
            return BadRequest();

        if (productDTO.Id == null)
            return BadRequest();

        await _productService.UpdateProduct(productDTO);

        return Ok(productDTO);

    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> DeleteCategory(int id)
    {
        var productDTO = await _productService.GetProductById(id);

        if (productDTO == null)
            return NotFound("Category not found");

        await _productService.DeleteProduct(productDTO.Id);

        return Ok(productDTO);
    }

}
