namespace ProductDemo.Server.Contracts.Products;

public record UpdateProductRequest(
    Guid Id,
    string SKU,
    string Title,
    string Description,
    Guid BuyerId,
    bool Active

    );

