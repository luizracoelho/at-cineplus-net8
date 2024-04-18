using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Services;

public interface ISessionService : IBaseService<Session>
{
    Task<Session> AddAsync(Session movie);
    Task<Session> UpdateAsync(Session movie);
    Task<IList<Session>> ListByMovieAndRoomAsync(long movieId, long roomId);
}