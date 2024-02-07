using ErrorOr;
using Mapster;
using MediatR;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Domain.Entities;
using ProductDemo.Server.Domain.Errors;

namespace ProductDemo.Server.Application.Commands.Products;

public record UpdateProductCommand(
    Guid Id,
    string SKU,
    string Title,
    string Description,
    Guid BuyerId,
    bool Active
) : IRequest<ErrorOr<Updated>>;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ErrorOr<Updated>>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(
        IProductRepository productRepository
    )
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync<Product>(command.Id);

        if (product is null) return DomainErrors.Product.NotFound;

        command.Adapt(product);

        _productRepository.Update(product);

        await _productRepository.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}

