using Mapster;
using ProductDemo.Server.Application.Abstract.Infrastructure;
using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Domain.Entities;
using ProductDemo.Server.Infrastructure.Notification;
using ProductDemo.Server.Persistence.Repositories.Common;
using System.Reflection;

namespace ProductDemo.Server.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly ProductModuleDbContext _dbContext;
    private readonly INotify _notify;

    private Queue<Notification> notifications = new Queue<Notification>();

    public ProductRepository(ProductModuleDbContext context, INotify notify) : base(context)
    {
        _dbContext = context;
        _notify = notify;
    }

    public override void Update(Product updatedProduct)
    {
        var product = _dbContext.Products.Find(updatedProduct.Id)!;
       

        if (product.Active && !updatedProduct.Active) {
            notifications.Enqueue(
                new Notification { 
                UserId =  product.BuyerId.ToString(), 
                  Message =   "the product"+ product.Title + " is set deactivated"
                }
                );
        }

        if(product.BuyerId != updatedProduct.BuyerId)
        {
            notifications.Enqueue(
                new Notification
                {
                    UserId = product.BuyerId.ToString(),
                    Message = "you are no longer the buyer of the product " + product.Title
                }) ;
            
                notifications.Enqueue(
                new Notification
                {
                    UserId = updatedProduct.BuyerId.ToString(),
                    Message = "you are now the buyer of the product " + product.Title
                }

                );
        }
        updatedProduct.Adapt(product);
        _dbContext.Update(product);

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = base.SaveChangesAsync(cancellationToken);

        while(notifications.Count > 0)
        {
            var notification = notifications.Dequeue();
            _notify.Notify(notification.UserId, notification.Message);
        }

        return result;
    }
}