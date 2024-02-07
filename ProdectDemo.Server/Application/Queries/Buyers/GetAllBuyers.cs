using ErrorOr;
using MediatR;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Application.Results;

namespace ProductDemo.Server.Application.Queries.Buyers;

public record GetAllBuyersQuery() : IRequest<ErrorOr<List<BuyerResult>>>;

public class GetAllBuyersHandler : IRequestHandler<GetAllBuyersQuery, ErrorOr<List<BuyerResult>>>
{
    private readonly IBuyerRepository _buyerRepository;

    public GetAllBuyersHandler(IBuyerRepository buyerRepository)
    {
        _buyerRepository = buyerRepository;
    }

    public async Task<ErrorOr<List<BuyerResult>>> Handle(GetAllBuyersQuery query, CancellationToken cancellationToken)
    {
        return await _buyerRepository.GetAllAsync<BuyerResult>();
    }
}
