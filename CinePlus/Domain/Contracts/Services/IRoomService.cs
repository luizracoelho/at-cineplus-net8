using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Services;

public interface IRoomService : IBaseService<Room>
{
    Task<IList<Room>> ListActivesAsync();
    Task<Room> AddAsync(Room movie);
    Task<Room> UpdateAsync(Room movie);
    Task<bool> ActivateAsync(long id);
    Task<bool> DeactivateAsync(long id);
}