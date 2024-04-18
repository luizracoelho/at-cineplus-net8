using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Exceptions;
using CinePlus.Domain.ViewModels.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace CinePlus.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class RoomsController : ControllerBase
{
    private readonly IRoomApp _app;

    public RoomsController(IRoomApp app) => _app = app;

    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        try
        {
            return Ok(await _app.ListAsync());
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

    [HttpGet("actives")]
    public async Task<IActionResult> ListActivesAsync()
    {
        try
        {
            return Ok(await _app.ListActivesAsync());
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
            return Ok(await _app.FindAsync(id));
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
    public async Task<IActionResult> AddAsync([FromBody] CreateRoomVm vm)
    {
        try
        {
            return Ok(await _app.AddAsync(vm));
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
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] CreateRoomVm vm)
    {
        try
        {
            return Ok(await _app.UpdateAsync(id, vm));
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
            return isSuccess ? Ok() : BadRequest();
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
            return isSuccess ? Ok() : BadRequest();
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
            return isSuccess ? Ok() : BadRequest();
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