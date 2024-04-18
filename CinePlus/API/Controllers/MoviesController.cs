using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Exceptions;
using CinePlus.Domain.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CinePlus.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class MoviesController : ControllerBase
{
    private readonly IMovieApp _app;

    public MoviesController(IMovieApp app) => _app = app;

    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var movies = await _app.ListAsync();
        return Ok(movies);
    }

    [HttpGet("actives")]
    public async Task<IActionResult> ListActivesAsync()
    {
        try
        {
            var movies = await _app.ListActivesAsync();
            return Ok(movies);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> FindAsync(long id)
    {
        try
        {
            var movie = await _app.FindAsync(id);
            return Ok(movie);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateMovieVm vm)
    {
        try
        {
            var movie = await _app.AddAsync(vm);
            return Ok(movie);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] CreateMovieVm vm)
    {
        try
        {
            var movie = await _app.UpdateAsync(id, vm);
            return Ok(movie);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        try
        {
            var isSuccess = await _app.RemoveAsync(id);

            if (!isSuccess)
                return BadRequest();

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch("{id:long}/activate")]
    public async Task<IActionResult> ActivateAsync(long id)
    {
        try
        {
            var isSuccess = await _app.ActivateAsync(id);

            if (!isSuccess)
                return BadRequest();

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch("{id:long}/deactivate")]
    public async Task<IActionResult> DeactivateAsync(long id)
    {
        try
        {
            var isSuccess = await _app.DeactivateAsync(id);

            if (!isSuccess)
                return BadRequest();

            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}