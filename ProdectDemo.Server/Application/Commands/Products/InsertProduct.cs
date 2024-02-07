using ErrorOr;
using MapsterMapper;
using MediatR;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Application.Commands.Products;

public record InsertProductCommand(
    string SKU,
    string Title,
    string Description,
    Guid BuyerId,
    bool Active

) : IRequest<ErrorOr<Guid>>;

public class InsertProductHandler : IRequestHandler<InsertProductCommand, ErrorOr<Guid>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public InsertProductHandler(
        IProductRepository productRepository,
        IMapper mapper

    )
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Guid>> Handle(InsertProductCommand command, CancellationToken cancellationToken)
    {
        var id = _productRepository.Insert(_mapper.Map<Product>(command));
        
        await _productRepository.SaveChangesAsync(cancellationToken);

        return id;
    }
}

