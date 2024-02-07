using Mapster;
using Microsoft.EntityFrameworkCore;
using ProductDemo.Server.Application.Abstract.Persistence.Common;

namespace ProductDemo.Server.Persistence.Repositories.Common;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DbContext DbContext;

    // the name of primary key of entity
    private readonly string _keyName;

    protected BaseRepository(DbContext dbContext)
    {
        DbContext = dbContext;
        _keyName = DbContext.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!.Properties
            .Select(x => x.Name).Single();
    }

    public virtual async Task<TResult?> GetAsync<TResult>(Guid id)
    {
        return await DbContext.Set<T>()
            .AsNoTracking()
            .Where(x => EF.Property<Guid>(x, _keyName) == id)
            .ProjectToType<TResult>()
            .FirstOrDefaultAsync();
    }


    public virtual async Task<List<TResult>> GetAllAsync<TResult>()
    => await DbContext.Set<T>().ProjectToType<TResult>().ToListAsync();

    public virtual Guid Insert(T entity)
    {
        DbContext.Set<T>().Add(entity);
        return (Guid)DbContext.Entry(entity).Property(_keyName).CurrentValue!;
    }


    public virtual void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }


    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await DbContext.Set<T>().FindAsync(id);
        if (entity is null) return;

        DbContext.Set<T>().Remove(entity);

    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }


}

