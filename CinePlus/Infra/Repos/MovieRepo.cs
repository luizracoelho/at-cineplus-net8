using CinePlus.Domain.Contracts.Context;
using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Models;
using CinePlus.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.Infra.Repos;

public class MovieRepo(IDataContext context) : BaseRepo<Movie>(context), IMovieRepo
{
    public override async Task<IList<Movie>> ListAsync()
        => await DbSet.OrderBy(movie => movie.Name).ToListAsync();

    public async Task<IList<Movie>> ListActivesAsync()
        => await DbSet.Where(movie => movie.Active)
            .OrderBy(movie => movie.Name)
            .ToListAsync();
}