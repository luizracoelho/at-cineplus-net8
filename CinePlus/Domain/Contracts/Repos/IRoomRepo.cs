using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Repos;

public interface IRoomRepo : IBaseRepo<Room>
{
    Task<IList<Room>> ListAsync();
    Task<IList<Room>> ListActivesAsync();
}