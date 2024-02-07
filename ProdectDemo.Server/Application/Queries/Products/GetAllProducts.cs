using ErrorOr;
using MediatR;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Application.Results;

namespace ProductDemo.Server.Application.Queries.Products;

public record GetAllProductsQuery() : IRequest<ErrorOr<List<ProductResult>>>;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<List<ProductResult>>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<List<ProductResult>>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync<ProductResult>();
    }
}
