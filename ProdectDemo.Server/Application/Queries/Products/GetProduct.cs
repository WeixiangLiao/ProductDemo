using ErrorOr;
using MediatR;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Application.Results;

namespace ProductDemo.Server.Application.Queries.Products;

public record GetProductQuery(
    Guid Id
) : IRequest<ErrorOr<ProductResult>>;

public class GetProductHandler : IRequestHandler<GetProductQuery, ErrorOr<ProductResult>>
{
    private readonly IProductRepository _productRepository;

    public GetProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<ProductResult>> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAsync<ProductResult>(query.Id);

        return result is null ? ProductDemo.Server.Domain.Errors.DomainErrors.Product.NotFound : result;

    }
}
