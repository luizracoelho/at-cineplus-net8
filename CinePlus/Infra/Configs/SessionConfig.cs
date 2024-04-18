using CinePlus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinePlus.Infra.Configs;

public class SessionConfig : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(session => session.Id);

        builder.HasOne(session => session.Movie)
            .WithMany(movie => movie.Sessions)
            .HasForeignKey(session => session.MovieId);

        builder.HasOne(session => session.Room)
            .WithMany(room => room.Sessions)
            .HasForeignKey(session => session.RoomId);
    }
}