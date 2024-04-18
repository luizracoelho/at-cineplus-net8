namespace CinePlus.Domain.ViewModels.Movies;

public class MovieVm
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public int DurationInMinutes { get; set; }
    public bool Active { get; set; }
}