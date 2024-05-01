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
    public async Task<IActionResult> ListAsync() => Ok(await app.ListAsync());

    [HttpGet("actives")]
    public async Task<IActionResult> ListActivesAsync() => Ok(await app.ListActivesAsync());

    [HttpGet("{id:long}")]
    public async Task<IActionResult> FindAsync(long id) => Ok(await app.FindAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateRoomVm vm) 
        => Ok(await app.AddAsync(vm));

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] CreateRoomVm vm) 
        => Ok(await app.UpdateAsync(id, vm));

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> RemoveAsync(long id)
    {
        var isSuccess = await app.RemoveAsync(id);
        return isSuccess ? Ok() : BadRequest();
    }

    [HttpPatch("{id:long}/activate")]
    public async Task<IActionResult> ActivateAsync(long id)
    {
        var isSuccess = await app.ActivateAsync(id);
        return isSuccess ? Ok() : BadRequest();
    }

    [HttpPatch("{id:long}/deactivate")]
    public async Task<IActionResult> DeactivateAsync(long id)
    {
        var isSuccess = await app.DeactivateAsync(id);
        return isSuccess ? Ok() : BadRequest();
    }
}