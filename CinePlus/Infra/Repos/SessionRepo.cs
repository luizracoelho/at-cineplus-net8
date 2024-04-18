using CinePlus.Domain.Contracts.Context;
using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Models;
using CinePlus.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.Infra.Repos;

public class SessionRepo : BaseRepo<Session>, ISessionRepo
{
    public SessionRepo(IDataContext context) : base(context)
    {
    }

    public async Task<IList<Session>> ListByMovieAndRoomAsync(long movieId, long roomId)
    {
        return await DbSet
            .Where(session =>
                session.MovieId == movieId &&
                session.RoomId == roomId
            )
            .Include(session => session.Movie)
            .Include(session => session.Room)
            .Include(session => session.Seats)
            .ToListAsync();
    }

    public override async Task<Session?> FindAsync(long id)
    {
        var session = await DbSet
                            .Include(session => session.Movie)
                            .Include(session => session.Room)
                            .Include(session => session.Seats)
                            .FirstOrDefaultAsync(session => session.Id == id);

        if (session == null) return session;
        
        foreach (var seat in session.Seats)
            seat.NullSession();

        return session;
    }
}