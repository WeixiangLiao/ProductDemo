using ErrorOr;
using Microsoft.EntityFrameworkCore;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Persistence.Repositories;

namespace ProductDemo.Server.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        var connectionString = configuration["DefaultConnection"];


        services.AddDbContext<DbContext, ProductModuleDbContext>((serviceProvider, optionsBuilder) =>
        {

            optionsBuilder
            .UseInMemoryDatabase("ProductModule");
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IBuyerRepository, BuyerRepository>();

        return services;
    }

}