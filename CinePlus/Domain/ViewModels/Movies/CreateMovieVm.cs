namespace CinePlus.Domain.ViewModels.Movies;

public class CreateMovieVm
{
    public required string Name { get; set; }
    public required string Image { get; set; }
    public int DurationInMinutes { get; set; }
}