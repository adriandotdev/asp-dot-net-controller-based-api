using Microsoft.EntityFrameworkCore;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}

    public DbSet<Product> Products {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(e => e.Products)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();
    }   
}