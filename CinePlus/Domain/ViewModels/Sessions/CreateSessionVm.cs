using CinePlus.Domain.ViewModels.Movies;
using CinePlus.Domain.ViewModels.Rooms;
using CinePlus.Domain.ViewModels.SessionSeats;

namespace CinePlus.Domain.ViewModels.Sessions;

public class CreateSessionVm
{
    public DateTime DateTime { get; set; }
    public long MovieId { get; set; }
    public long RoomId { get; set; }
    public decimal Price { get; set; }
}