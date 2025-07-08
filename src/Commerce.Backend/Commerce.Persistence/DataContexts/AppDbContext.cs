using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductManufacturer> ProductManufacturers => Set<ProductManufacturer>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Section> Sections => Set<Section>();
}
