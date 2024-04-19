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
        try
        {
            var movies = await app.ListActivesAsync();
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
            var movie = await app.FindAsync(id);
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
            var movie = await app.AddAsync(vm);
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
            var movie = await app.UpdateAsync(id, vm);
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
            var isSuccess = await app.RemoveAsync(id);

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
            var isSuccess = await app.ActivateAsync(id);

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
            var isSuccess = await app.DeactivateAsync(id);

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