using CinePlus.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinePlus.Infra.Configs;

public class MovieConfig : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(movie => movie.Id);

        builder.Property(movie => movie.Name).IsRequired();
        builder.Property(movie => movie.Image).IsRequired();
    }
}