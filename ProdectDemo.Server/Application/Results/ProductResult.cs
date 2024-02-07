using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Application.Results;

public record ProductResult(
Guid Id,
string SKU,
string Title,
string Description,
Guid BuyerId,
BuyerResult Buyer,
bool Active
);
