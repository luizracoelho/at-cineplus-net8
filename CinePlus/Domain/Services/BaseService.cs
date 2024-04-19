using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Exceptions;
using CinePlus.Infra.Repos;
using FluentValidation;

namespace CinePlus.Domain.Services;

public abstract class BaseService<T>(IBaseRepo<T> repo) : IBaseService<T> where T : class
{
    public virtual async Task<IList<T>> ListAsync()
        => await repo.ListAsync();

    public virtual async Task<T> FindAsync(long id)
    {
        if (id <= 0) throw new NotFoundException("Não encontrado.");

        var entity = await repo.FindAsync(id);
        if (entity == null) throw new NotFoundException("Não encontrado.");

        return entity;
    }

    public virtual async Task<bool> RemoveAsync(long id)
    {
        var entity = await FindAsync(id);
        return await repo.RemoveAsync(entity);
    }
}