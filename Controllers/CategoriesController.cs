using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        
        var categories = await _categoryService.GetCategoriesAsync();

        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDTO category)
    {
        
        var newCategoryId =  await _categoryService.CreateCategoryAsync(category);

        return CreatedAtAction(nameof(GetCategories), new {id = newCategoryId}, category);
    }
}