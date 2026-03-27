using CloudProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloudProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Unique UrlSlug
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.UrlSlug)
            .IsUnique();

        modelBuilder.Entity<Category>()
            .HasIndex(c => c.UrlSlug)
            .IsUnique();

        // Many-to-many + join table name
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity(j => j.ToTable("ProductCategories"));

        // Price precision
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);
    }
}