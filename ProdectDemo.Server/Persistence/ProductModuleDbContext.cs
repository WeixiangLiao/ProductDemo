using Microsoft.EntityFrameworkCore;
using ProductDemo.Server.Domain.Entities;
using ProductDemo.Server.Persistence.Configurations;

namespace ProductDemo.Server.Persistence;

public class ProductModuleDbContext : DbContext
{
    public ProductModuleDbContext(DbContextOptions<ProductModuleDbContext> options) : base(options)
    {
    }


    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Buyer> Buyers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ProductModule");



        modelBuilder.ConfigureProduct();
        modelBuilder.ConfigureBuyer();

    }
}