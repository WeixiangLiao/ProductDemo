using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Persistence.Configurations;

public static class ProductConfigurations
{
    public static void ConfigureProduct(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");


            // -- Table Properties --
            // primary key
            entity.HasKey(e => e.Id);

            entity.ConfigureProperties();

            entity.ConfigureForeignKeys();

            entity.ConfigureIndexes();


            // -- Query Behaviors --
            entity.ConfigureQueryFilters();

            entity.ConfigureAutoIncludes();
        });
    }

    private static void ConfigureProperties(this EntityTypeBuilder<Product> entity)
    {
    }

    private static void ConfigureForeignKeys(this EntityTypeBuilder<Product> entity)
    {
        entity.HasOne(x => x.Buyer)
            .WithMany();
    }

    private static void ConfigureIndexes(this EntityTypeBuilder<Product> entity)
    {

        entity.HasIndex(e => e.SKU).IsUnique();
        entity.HasIndex(e => e.Title);
    }

    private static void ConfigureQueryFilters(this EntityTypeBuilder<Product> entity)
    {
    }

    private static void ConfigureAutoIncludes(this EntityTypeBuilder<Product> entity)
    {
    }

}

