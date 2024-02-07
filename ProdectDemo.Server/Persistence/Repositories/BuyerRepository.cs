using ProductDemo.Server.Application.Abstract.Persistence;
using ProductDemo.Server.Domain.Entities;
using ProductDemo.Server.Persistence;
using ProductDemo.Server.Persistence.Repositories.Common;

namespace ProductDemo.Server.Persistence.Repositories;

public class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
{
    private readonly ProductModuleDbContext _dbContext;

    public BuyerRepository(ProductModuleDbContext context) : base(context)
    {
        _dbContext = context;
    }
}