using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.ViewModels.Rooms;

namespace CinePlus.APP;

public class RoomApp(IRoomService service, IMapper mapper) : IRoomApp
{
    public async Task<IList<RoomVm>> ListAsync()
    {
        var rooms = await service.ListAsync();
        return mapper.Map<IList<RoomVm>>(rooms);
    }

    public async Task<IList<RoomVm>> ListActivesAsync()
    {
        var rooms = await service.ListActivesAsync();
        return mapper.Map<IList<RoomVm>>(rooms);
    }

    public async Task<RoomVm> FindAsync(long id)
    {
        var room = await service.FindAsync(id);
        return mapper.Map<RoomVm>(room);
    }

    public async Task<RoomVm> AddAsync(CreateRoomVm vm)
    {
        var room = new Room(vm.Name, vm.RowsCount, vm.SeatsByRow);
        await service.AddAsync(room);

        return mapper.Map<RoomVm>(room);
    }

    public async Task<RoomVm> UpdateAsync(long id, CreateRoomVm vm)
    {
        var room = await service.FindAsync(id);
        
        room.Update(vm.Name, vm.RowsCount, vm.SeatsByRow);
        await service.UpdateAsync(room);

        return mapper.Map<RoomVm>(room);
    }

    public async Task<bool> RemoveAsync(long id) 
        => await service.RemoveAsync(id);

    public async Task<bool> ActivateAsync(long id) 
        => await service.ActivateAsync(id);

    public async Task<bool> DeactivateAsync(long id) 
        => await service.DeactivateAsync(id);
}