using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.ViewModels.Rooms;

namespace CinePlus.APP;

public class RoomApp : IRoomApp
{
    private readonly IRoomService _service;
    private readonly IMapper _mapper;

    public RoomApp(IRoomService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IList<RoomVm>> ListAsync()
    {
        var rooms = await _service.ListAsync();
        return _mapper.Map<IList<RoomVm>>(rooms);
    }

    public async Task<IList<RoomVm>> ListActivesAsync()
    {
        var rooms = await _service.ListActivesAsync();
        return _mapper.Map<IList<RoomVm>>(rooms);
    }

    public async Task<RoomVm> FindAsync(long id)
    {
        var room = await _service.FindAsync(id);
        return _mapper.Map<RoomVm>(room);
    }

    public async Task<RoomVm> AddAsync(CreateRoomVm vm)
    {
        var room = new Room(vm.Name, vm.RowsCount, vm.SeatsByRow);
        await _service.AddAsync(room);

        return _mapper.Map<RoomVm>(room);
    }

    public async Task<RoomVm> UpdateAsync(long id, CreateRoomVm vm)
    {
        var room = await _service.FindAsync(id);
        
        room.Update(vm.Name, vm.RowsCount, vm.SeatsByRow);
        await _service.UpdateAsync(room);

        return _mapper.Map<RoomVm>(room);
    }

    public async Task<bool> RemoveAsync(long id) 
        => await _service.RemoveAsync(id);

    public async Task<bool> ActivateAsync(long id) 
        => await _service.ActivateAsync(id);

    public async Task<bool> DeactivateAsync(long id) 
        => await _service.DeactivateAsync(id);
}