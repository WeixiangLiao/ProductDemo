namespace ProductDemo.Server.Application.Abstract.Persistence.Common;


public interface IBaseRepository<T> where T : class
{
    public Task<TResult?> GetAsync<TResult>(Guid id);

    public Task<List<TResult>> GetAllAsync<TResult>();

    public Guid Insert(T entity);

    public void Update(T entity);

    public Task DeleteAsync(Guid id);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);



}

