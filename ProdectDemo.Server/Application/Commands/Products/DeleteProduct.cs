using ErrorOr;
using MediatR;
using ProductDemo.Server.Application.Abstract.Persistence;

namespace ProductDemo.Server.Application.Commands.Products;

public record DeleteProductCommand
(
    Guid Id
) : IRequest<ErrorOr<Deleted>>;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Deleted>>
{
    private readonly IProductRepository _productRepository;


    public DeleteProductHandler(
        IProductRepository product

    )
    {
        _productRepository = product;

    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteProductCommand query, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteAsync(query.Id);

        await _productRepository.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}
