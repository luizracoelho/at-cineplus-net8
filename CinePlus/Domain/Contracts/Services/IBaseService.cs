namespace CinePlus.Domain.Contracts.Services;

public interface IBaseService<T> where T : class
{
    Task<IList<T>> ListAsync();
    Task<T> FindAsync(long id);
    Task<bool> RemoveAsync(long id);
}