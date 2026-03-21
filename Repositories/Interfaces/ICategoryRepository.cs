public interface ICategoryRepository
{
    
    Task<List<Category>> GetAllAsync();
  
    Task CreateAsync(Category category);

    Task RemoveByIdAsync(int id);

    Task <Category?> GetByIdAsync(int id);
}