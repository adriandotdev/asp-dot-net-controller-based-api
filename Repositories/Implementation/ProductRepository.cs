using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Product product)
    {
       await _context.Products.AddAsync(product);

       await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        return product;
    }

    public async Task RemoveByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id) ?? throw new KeyNotFoundException();

        _context.Remove(product);

        await _context.SaveChangesAsync();
    }
}