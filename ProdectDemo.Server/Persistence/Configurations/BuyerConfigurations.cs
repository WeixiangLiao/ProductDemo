using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Persistence.Configurations;

public static class BuyerConfigurations
{
    public static void ConfigureBuyer(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.ToTable("Buyer");


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

    private static void ConfigureProperties(this EntityTypeBuilder<Buyer> entity)
    {

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.Property(e => e.Email).HasMaxLength(100);

    }

    private static void ConfigureForeignKeys(this EntityTypeBuilder<Buyer> entity)
    {
    }

    private static void ConfigureIndexes(this EntityTypeBuilder<Buyer> entity)
    {

        entity.HasIndex(e => e.Name);

    }

    private static void ConfigureQueryFilters(this EntityTypeBuilder<Buyer> entity)
    {
    }

    private static void ConfigureAutoIncludes(this EntityTypeBuilder<Buyer> entity)
    {
    }

}

