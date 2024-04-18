using CinePlus.Domain.Contracts.Context;
using CinePlus.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.Infra.Context;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionSeat> SessionSeats { get; set; }
}