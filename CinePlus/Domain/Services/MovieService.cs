using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Validators;
using FluentValidation;

namespace CinePlus.Domain.Services;

public class MovieService : BaseService<Movie>, IMovieService
{
    private readonly IMovieRepo _repo;
    private readonly MovieValidator _validator;

    public MovieService(IMovieRepo repo, MovieValidator validator) : base(repo)
    {
        _repo = repo;
        _validator = validator;
    }

    public async Task<IList<Movie>> ListActivesAsync()
        => await _repo.ListActivesAsync();

    public async Task<Movie> AddAsync(Movie movie)
    {
        await _validator.ValidateAndThrowAsync(movie);
        return await _repo.AddAsync(movie);
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        var movieDb = await FindAsync(movie.Id);

        movieDb.Update(movie.Name, movie.Image, movie.DurationInMinutes);

        await _validator.ValidateAndThrowAsync(movieDb);

        return await _repo.UpdateAsync(movieDb);
    }

    public async Task<bool> ActivateAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Activate();

        if (!result) throw new Exception("Não foi possível ativar o filme, pois ele já se encontra ativo.");

        await _repo.UpdateAsync(movieDb);

        return true;
    }

    public async Task<bool> DeactivateAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Deactivate();

        if (!result) throw new Exception("Não foi possível desativar o filme, pois ele já se encontra inativo.");

        await _repo.UpdateAsync(movieDb);

        return true;
    }
}