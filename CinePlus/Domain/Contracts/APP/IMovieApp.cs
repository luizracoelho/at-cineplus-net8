using CinePlus.Domain.ViewModels.Movies;

namespace CinePlus.Domain.Contracts.APP;

public interface IMovieApp
{
    Task<IList<MovieVm>> ListAsync();
    Task<IList<MovieVm>> ListActivesAsync();
    Task<MovieVm> FindAsync(long id);
    Task<MovieVm> AddAsync(CreateMovieVm vm);
    Task<MovieVm> UpdateAsync(long id, CreateMovieVm vm);
    Task<bool> RemoveAsync(long id);
    Task<bool> ActivateAsync(long id);
    Task<bool> DeactivateAsync(long id);
}