using CinePlus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinePlus.Infra.Configs;

public class SessionSeatConfig : IEntityTypeConfiguration<SessionSeat>
{
    public void Configure(EntityTypeBuilder<SessionSeat> builder)
    {
        builder.HasKey(seat => seat.Id);

        builder.HasOne(seat => seat.Session)
            .WithMany(session => session.Seats)
            .HasForeignKey(seat => seat.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}