namespace CinePlus.Domain.ViewModels.Rooms;

public class RoomVm
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public int RowsCount { get; set; }
    public int SeatsByRow { get; set; }
    public bool Active { get; set; }
}