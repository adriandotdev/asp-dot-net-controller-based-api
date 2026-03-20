public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);

    Task RemoveByIdAsync(int id);

    Task CreateAsync(Product product);
}