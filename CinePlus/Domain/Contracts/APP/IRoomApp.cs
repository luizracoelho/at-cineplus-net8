using CinePlus.Domain.ViewModels.Rooms;

namespace CinePlus.Domain.Contracts.APP;

public interface IRoomApp
{
    Task<IList<RoomVm>> ListAsync();
    Task<IList<RoomVm>> ListActivesAsync();
    Task<RoomVm> FindAsync(long id);
    Task<RoomVm> AddAsync(CreateRoomVm vm);
    Task<RoomVm> UpdateAsync(long id, CreateRoomVm vm);
    Task<bool> RemoveAsync(long id);
    Task<bool> ActivateAsync(long id);
    Task<bool> DeactivateAsync(long id);
}