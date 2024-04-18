using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Services;
using CinePlus.Domain.ViewModels.Movies;

namespace CinePlus.APP;

public class MovieApp : IMovieApp
{
    private readonly IMovieService _service;
    private readonly IMapper _mapper;

    public MovieApp(IMovieService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IList<MovieVm>> ListAsync()
    {
        var movies = await _service.ListAsync();
        var moviesVm = _mapper.Map<IList<MovieVm>>(movies);
        return moviesVm;
    }

    public async Task<IList<MovieVm>> ListActivesAsync()
    {
        var movies = await _service.ListActivesAsync();
        return _mapper.Map<IList<MovieVm>>(movies);
    }

    public async Task<MovieVm> FindAsync(long id)
    {
        var movie = await _service.FindAsync(id);
        var movieVm = _mapper.Map<MovieVm>(movie);
        return movieVm;
    }

    public async Task<MovieVm> AddAsync(CreateMovieVm vm)
    {
        var movie = new Movie(vm.Name, vm.Image, vm.DurationInMinutes);
        await _service.AddAsync(movie);

        var movieVm = _mapper.Map<MovieVm>(movie);
        
        return movieVm;
    }

    public async Task<MovieVm> UpdateAsync(long id, CreateMovieVm vm)
    {
        var movie = await _service.FindAsync(id);
        
        movie.Update(vm.Name, vm.Image, vm.DurationInMinutes);
        await _service.UpdateAsync(movie);

        var movieVm = _mapper.Map<MovieVm>(movie);
        
        return movieVm;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var isSuccess = await _service.RemoveAsync(id);
        return isSuccess;
    }

    public async Task<bool> ActivateAsync(long id)
    {
        var isSuccess = await _service.ActivateAsync(id);
        return isSuccess;
    }

    public async Task<bool> DeactivateAsync(long id)
    {
        var isSuccess = await _service.DeactivateAsync(id);
        return isSuccess;
    }
}