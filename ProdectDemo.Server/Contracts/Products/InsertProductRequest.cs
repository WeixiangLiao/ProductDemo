namespace ProductDemo.Server.Contracts.Products;

public record InsertProductRequest(
    string SKU,
    string Title,
    string Description,
    Guid BuyerId,
    bool Active
    );

