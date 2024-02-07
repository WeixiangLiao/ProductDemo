using ProductDemo.Server.Application.Results;

namespace ProductDemo.Server.Contracts.Products;
public record ProductResponse(
Guid Id,
string SKU,
string Title,
string Description,
Guid BuyerId,
BuyerResult Buyer,
bool Active
);
