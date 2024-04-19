using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Validators;
using FluentValidation;

namespace CinePlus.Domain.Services;

public class SessionService(ISessionRepo repo, SessionValidator validator) : BaseService<Session>(repo), ISessionService
{
    public async Task<Session> AddAsync(Session session)
    {
        await validator.ValidateAndThrowAsync(session);
        return await repo.AddAsync(session);
    }

    public async Task<Session> UpdateAsync(Session session)
    {
        var sessionDb = await FindAsync(session.Id);

        sessionDb.Update(session.DateTime, session.MovieId, session.RoomId, session.Price);

        await validator.ValidateAndThrowAsync(sessionDb);

        return await repo.UpdateAsync(sessionDb);
    }

    public async Task<IList<Session>> ListByMovieAndRoomAsync(long movieId, long roomId)
        => await repo.ListByMovieAndRoomAsync(movieId, roomId);
}