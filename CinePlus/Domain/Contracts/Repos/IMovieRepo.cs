using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Repos;

public interface IMovieRepo : IBaseRepo<Movie>
{
    Task<IList<Movie>> ListAsync();
    Task<IList<Movie>> ListActivesAsync();
}