namespace CinePlus.Domain.Contracts.Repos;

public interface IBaseRepo<T> where T : class
{
    Task<IList<T>> ListAsync();
    Task<T?> FindAsync(long id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> RemoveAsync(T entity);
}