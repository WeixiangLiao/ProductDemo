namespace ProductDemo.Server.Contracts.Buyers;
public record BuyerResponse(
        Guid Id,
        string Name,
        string Email
);
