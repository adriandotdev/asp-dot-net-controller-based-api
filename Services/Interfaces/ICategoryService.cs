public interface ICategoryService
{
    Task<List<CategoryDTO>> GetCategoriesAsync();

    Task<int> CreateCategoryAsync(CreateCategoryDTO category);
}