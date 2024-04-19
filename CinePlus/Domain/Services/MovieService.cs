using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Validators;
using FluentValidation;

namespace CinePlus.Domain.Services;

public class MovieService(IMovieRepo repo, MovieValidator validator) : BaseService<Movie>(repo), IMovieService
{
    public async Task<IList<Movie>> ListActivesAsync()
        => await repo.ListActivesAsync();

    public async Task<Movie> AddAsync(Movie movie)
    {
        await validator.ValidateAndThrowAsync(movie);
        return await repo.AddAsync(movie);
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        var movieDb = await FindAsync(movie.Id);

        movieDb.Update(movie.Name, movie.Image, movie.DurationInMinutes);

        await validator.ValidateAndThrowAsync(movieDb);

        return await repo.UpdateAsync(movieDb);
    }

    public async Task<bool> ActivateAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Activate();

        if (!result) throw new Exception("Não foi possível ativar o filme, pois ele já se encontra ativo.");

        await repo.UpdateAsync(movieDb);

        return true;
    }

    public async Task<bool> DeactivateAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Deactivate();

        if (!result) throw new Exception("Não foi possível desativar o filme, pois ele já se encontra inativo.");

        await repo.UpdateAsync(movieDb);

        return true;
    }
}