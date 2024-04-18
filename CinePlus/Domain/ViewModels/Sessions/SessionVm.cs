using CinePlus.Domain.ViewModels.Movies;
using CinePlus.Domain.ViewModels.Rooms;
using CinePlus.Domain.ViewModels.SessionSeats;

namespace CinePlus.Domain.ViewModels.Sessions;

public class SessionVm
{
    public long Id { get; set; }
    public DateTime DateTime { get; set; }
    public long MovieId { get; set; }
    public MovieVm? Movie { get; set; }
    public long RoomId { get; set; }
    public RoomVm? Room { get; set; }
    public decimal Price { get; set; }
    public IList<SessionSeatVm> Seats { get; set; }
}