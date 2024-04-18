using CinePlus.Domain.Contracts.Context;
using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Models;
using CinePlus.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.Infra.Repos;

public class SessionSeatRepo : BaseRepo<SessionSeat>, ISessionSeatRepo
{
    public SessionSeatRepo(IDataContext context) : base(context)
    {
    }

    public override async Task<IList<SessionSeat>> ListAsync()
        => await DbSet.OrderBy(seat => seat.Session).ToListAsync();
}