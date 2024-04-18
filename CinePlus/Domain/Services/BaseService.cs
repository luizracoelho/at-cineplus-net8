using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Exceptions;
using CinePlus.Infra.Repos;
using FluentValidation;

namespace CinePlus.Domain.Services;

public abstract class BaseService<T> : IBaseService<T> where T : class
{
    private readonly IBaseRepo<T> _repo;

    protected BaseService(IBaseRepo<T> repo) => _repo = repo;

    public virtual async Task<IList<T>> ListAsync()
        => await _repo.ListAsync();
    
    public virtual async Task<T> FindAsync(long id)
    {
        if (id <= 0) throw new NotFoundException("Não encontrado.");
        
        var entity = await _repo.FindAsync(id);
        if (entity == null) throw new NotFoundException("Não encontrado.");

        return entity;
    }
    
    public virtual async Task<bool> RemoveAsync(long id)
    {
        var entity = await FindAsync(id);
        return await _repo.RemoveAsync(entity);
    }
}