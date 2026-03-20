using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductContext _context;
    private readonly IProductService _productService;

    public ProductsController(ProductContext context, IProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);

        if (product is null) return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProductById(int id)
    {
        await _productService.RemoveProductByIdAsync(id);

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateProductDTO product)
    {
        if (product is null) return BadRequest();

        var newProductId = await _productService.CreateProductAsync(product);

        return CreatedAtAction(nameof(GetProductById), new {id = newProductId}, product);
    }
}