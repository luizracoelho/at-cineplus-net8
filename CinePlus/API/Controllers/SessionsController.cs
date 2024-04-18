using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Exceptions;
using CinePlus.Domain.ViewModels.Sessions;
using CinePlus.Domain.ViewModels.SessionSeats;
using Microsoft.AspNetCore.Mvc;

namespace CinePlus.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class SessionsController : ControllerBase
{
    private readonly ISessionApp _app;

    public SessionsController(ISessionApp app) => _app = app;

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

    [HttpGet("movie/{movieId:long}/room/{roomId:long}")]
    public async Task<IActionResult> ListByMovieAndRoomAsync(long movieId, long roomId)
    {
        try
        {
            return Ok(await _app.ListByMovieAndRoomAsync(movieId, roomId));
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
    public async Task<IActionResult> AddAsync([FromBody] CreateSessionVm vm)
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
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] CreateSessionVm vm)
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

    [HttpPost("{sessionId:long}/seats")]
    public async Task<IActionResult> AddSeatAsync(long sessionId, [FromBody] CreateSessionSeatVm vm)
    {
        try
        {
            return Ok(await _app.AddSeatAsync(sessionId, vm));
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

    [HttpPut("{sessionId:long}/seats/{id:long}")]
    public async Task<IActionResult> UpdateSeatAsync(long sessionId, long id, [FromBody] CreateSessionSeatVm vm)
    {
        try
        {
            return Ok(await _app.UpdateSeatAsync(sessionId, id, vm));
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

    [HttpDelete("{sessionId:long}/seats/{id:long}")]
    public async Task<IActionResult> RemoveSeatAsync(long sessionId, long id)
    {
        try
        {
            return Ok(await _app.RemoveSeatAsync(sessionId, id));
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

    [HttpPatch("{sessionId:long}/seats/{id:long}/reserve")]
    public async Task<IActionResult> ReserveSeatAsync(long sessionId, long id, [FromBody] ReserveSessionSeatVm vm)
    {
        try
        {
            return Ok(await _app.ReserveSeatAsync(sessionId, id, vm));
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

    [HttpPatch("{sessionId:long}/seats/{id:long}/cancel-reserve")]
    public async Task<IActionResult> CancelReserveSeatAsync(long sessionId, long id)
    {
        try
        {
            return Ok(await _app.CancelReserveSeatAsync(sessionId, id));
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

    [HttpPatch("{sessionId:long}/seats/{id:long}/confirm-reserve")]
    public async Task<IActionResult> ConfirmReserveSeatAsync(long sessionId, long id)
    {
        try
        {
            return Ok(await _app.ConfirmReserveSeatAsync(sessionId, id));
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

    [HttpPatch("{sessionId:long}/seats/{id:long}/cancel-confirmation")]
    public async Task<IActionResult> CancelConfirmationSeatAsync(long sessionId, long id)
    {
        try
        {
            return Ok(await _app.CancelConfirmationSeatAsync(sessionId, id));
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