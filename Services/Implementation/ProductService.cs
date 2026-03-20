using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDTO?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product is null) return null;
        
        var productDto = new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price  
        };

        return productDto;
    }

    public async Task<List<ProductDTO>> GetProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        }).ToList();
    }

    public async Task RemoveProductByIdAsync(int id)
    {
        await _productRepository.RemoveByIdAsync(id);
    }

    public async Task<int> CreateProductAsync(CreateProductDTO product)
    {   
        var newProduct = new Product
        {
            Name = product.Name,
            Price = product.Price ?? 0
        };

        await _productRepository.CreateAsync(newProduct);

        return newProduct.Id;
    }
}