namespace ProductDemo.Server.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string SKU { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Guid BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
        public bool Active { get; set; }
    }
}
