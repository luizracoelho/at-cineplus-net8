using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Services;
using CinePlus.Domain.ViewModels.Movies;

namespace CinePlus.APP;

public class MovieApp(IMovieService service, IMapper mapper) : IMovieApp
{
    public async Task<IList<MovieVm>> ListAsync()
    {
        var movies = await service.ListAsync();
        var moviesVm = mapper.Map<IList<MovieVm>>(movies);
        return moviesVm;
    }

    public async Task<IList<MovieVm>> ListActivesAsync()
    {
        var movies = await service.ListActivesAsync();
        return mapper.Map<IList<MovieVm>>(movies);
    }

    public async Task<MovieVm> FindAsync(long id)
    {
        var movie = await service.FindAsync(id);
        var movieVm = mapper.Map<MovieVm>(movie);
        return movieVm;
    }

    public async Task<MovieVm> AddAsync(CreateMovieVm vm)
    {
        var movie = new Movie(vm.Name, vm.Image, vm.DurationInMinutes);
        await service.AddAsync(movie);

        var movieVm = mapper.Map<MovieVm>(movie);
        
        return movieVm;
    }

    public async Task<MovieVm> UpdateAsync(long id, CreateMovieVm vm)
    {
        var movie = await service.FindAsync(id);
        
        movie.Update(vm.Name, vm.Image, vm.DurationInMinutes);
        await service.UpdateAsync(movie);

        var movieVm = mapper.Map<MovieVm>(movie);
        
        return movieVm;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var isSuccess = await service.RemoveAsync(id);
        return isSuccess;
    }

    public async Task<bool> ActivateAsync(long id)
    {
        var isSuccess = await service.ActivateAsync(id);
        return isSuccess;
    }

    public async Task<bool> DeactivateAsync(long id)
    {
        var isSuccess = await service.DeactivateAsync(id);
        return isSuccess;
    }
}