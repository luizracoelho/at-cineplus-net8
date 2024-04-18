using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Services;

public interface IMovieService : IBaseService<Movie>
{
    Task<IList<Movie>> ListActivesAsync();
    Task<Movie> AddAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> ActivateAsync(long id);
    Task<bool> DeactivateAsync(long id);
}