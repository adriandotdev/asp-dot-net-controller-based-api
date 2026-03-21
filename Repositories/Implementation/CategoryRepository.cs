using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
       var categories =  await _context.Categories.ToListAsync();

        return categories;
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        return category;
    }

    public async Task RemoveByIdAsync(int id)
    {
        var categoryToDelete = await _context.Categories.FindAsync(id) ?? throw new KeyNotFoundException();

        _context.Categories.Remove(categoryToDelete);

        await _context.SaveChangesAsync();
    }
}