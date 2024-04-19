namespace CinePlus.Domain.Models;

public class Session(DateTime dateTime, long movieId, long roomId, decimal price)
{
    #region Properties

    public long Id { get; private set; } = 0;
    public DateTime DateTime { get; private set; } = dateTime;
    public long MovieId { get; private set; } = movieId;
    public Movie? Movie { get; private set; }
    public long RoomId { get; private set; } = roomId;
    public Room? Room { get; private set; }
    public decimal Price { get; private set; } = price;
    public IList<SessionSeat> Seats { get; private set; } = [];

    #endregion
    
    #region Methods

    public void Update(DateTime dateTime, long movieId, long roomId, decimal price)
    {
        DateTime = dateTime;
        MovieId = movieId;
        RoomId = roomId;
        Price = price;
    }

    public override string ToString()
    {
        return $"[{Id}] DateTime: {DateTime} | MovieId: {MovieId} | RoomId: {RoomId} | Price: {Price}";
    }

    #endregion
}