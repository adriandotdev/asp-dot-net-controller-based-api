using System.Diagnostics;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> CreateCategoryAsync(CreateCategoryDTO category)
    {
        var newCategory = new Category
        {
          Name = category.Name  
        };

        await _categoryRepository.CreateAsync(newCategory);

        return newCategory.Id;
    }

    public async Task<List<CategoryDTO>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        var categoryDtos = categories.Select(s => new CategoryDTO
        {
             Id = s.Id,
             Name = s.Name
        }).ToList();

        return categoryDtos;
    }
}