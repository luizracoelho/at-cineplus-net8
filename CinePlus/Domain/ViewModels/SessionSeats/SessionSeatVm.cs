using CinePlus.Domain.Enums;
using CinePlus.Domain.ViewModels.Sessions;

namespace CinePlus.Domain.ViewModels.SessionSeats;

public class SessionSeatVm
{
    public long Id { get; set; }
    public required string Seat { get; set; }
    public SessionSeatStatus Status { get; set; }
    public long SessionId { get; set; }
    public SessionVm? Session { get; set; }
    public string? Document { get; set; }
}