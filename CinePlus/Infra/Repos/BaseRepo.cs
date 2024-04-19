using CinePlus.Domain.Contracts.Context;
using CinePlus.Domain.Contracts.Repos;
using CinePlus.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.Infra.Repos;

public abstract class BaseRepo<T>(IDataContext context) : IBaseRepo<T> where T : class
{
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public virtual async Task<IList<T>> ListAsync()
        => await DbSet.ToListAsync();

    public virtual async Task<T?> FindAsync(long id)
        => await DbSet.FindAsync(id);

    public virtual async Task<T> AddAsync(T entity)
    {
        DbSet.Add(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<bool> RemoveAsync(T entity)
    {
        DbSet.Remove(entity);
        await context.SaveChangesAsync();

        return true;
    }
}