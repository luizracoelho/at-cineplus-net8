using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Exceptions;
using CinePlus.Domain.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinePlus.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class MoviesController(IMovieApp app) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var movies = await app.ListAsync();
        return Ok(movies);
    }

    [HttpGet("actives")]
    public async Task<IActionResult> ListActivesAsync()
    {
        var movies = await app.ListActivesAsync();
        return Ok(movies);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> FindAsync(long id)
    {
        var movie = await app.FindAsync(id);
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateMovieVm vm)
    {
        var movie = await app.AddAsync(vm);
        return Ok(movie);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] CreateMovieVm vm)
    {
        var movie = await app.UpdateAsync(id, vm);
        return Ok(movie);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        var isSuccess = await app.RemoveAsync(id);

        if (!isSuccess)
            return BadRequest();

        return Ok();
    }

    [HttpPatch("{id:long}/activate")]
    public async Task<IActionResult> ActivateAsync(long id)
    {
        var isSuccess = await app.ActivateAsync(id);

        if (!isSuccess)
            return BadRequest();

        return Ok();
    }

    [HttpPatch("{id:long}/deactivate")]
    public async Task<IActionResult> DeactivateAsync(long id)
    {
        var isSuccess = await app.DeactivateAsync(id);

        if (!isSuccess)
            return BadRequest();

        return Ok();
    }
}