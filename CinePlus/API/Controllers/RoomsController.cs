using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Exceptions;
using CinePlus.Domain.ViewModels.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace CinePlus.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class RoomsController(IRoomApp app) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        try
        {
            return Ok(await app.ListAsync());
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
            return Ok(await app.ListActivesAsync());
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
            return Ok(await app.FindAsync(id));
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
            return Ok(await app.AddAsync(vm));
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
            return Ok(await app.UpdateAsync(id, vm));
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
            var isSuccess = await app.ActivateAsync(id);
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
            var isSuccess = await app.DeactivateAsync(id);
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