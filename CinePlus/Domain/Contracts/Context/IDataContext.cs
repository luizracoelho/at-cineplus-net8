using Microsoft.EntityFrameworkCore;

namespace CinePlus.Domain.Contracts.Context;

public interface IDataContext
{
    DbSet<T> Set<T>() where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}