public interface IProductService
{
    Task<List<ProductDTO>> GetProductsAsync();

    Task<ProductDTO?> GetProductByIdAsync(int id);

    Task RemoveProductByIdAsync(int id);

    Task<int> CreateProductAsync(CreateProductDTO product);
}