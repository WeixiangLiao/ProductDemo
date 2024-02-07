using Mapster;
using ProductDemo.Server.Application.Commands.Products;
using ProductDemo.Server.Application.Results;
using ProductDemo.Server.Contracts.Products;
using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Application;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductResult>()
            .Map(dest => dest.SKU, src => src.SKU);

        config.NewConfig<ProductResult, ProductResponse>()
            .Map(dest => dest.SKU, src => src.SKU);


        config.NewConfig<InsertProductRequest, InsertProductCommand>()
            .Map(dest => dest.SKU, src => src.SKU);


        config.NewConfig<InsertProductCommand, Product>()
            .Map(dest => dest.SKU, src => src.SKU);


        config.NewConfig<UpdateProductRequest, UpdateProductCommand>()
            .Map(dest => dest.SKU, src => src.SKU);


        config.NewConfig<UpdateProductCommand, Product>()
            .Map(dest => dest.SKU, src => src.SKU);

    }
}

