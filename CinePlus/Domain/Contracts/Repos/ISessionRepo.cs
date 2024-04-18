using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Repos;

public interface ISessionRepo : IBaseRepo<Session>
{
    Task<IList<Session>> ListByMovieAndRoomAsync(long movieId, long roomId);
}