using ProductDemo.Server.Application.Abstract.Persistence.Common;
using ProductDemo.Server.Domain.Entities;

namespace ProductDemo.Server.Application.Abstract.Persistence;

public interface IProductRepository : IBaseRepository<Product>
{


    /*
     For update 
     if active is set to false from true, send a notification 
    if buyer is switched, send a notification
     */


}