namespace CinePlus.Domain.Models;

public class Session
{
    #region Properties

    public long Id { get; private set; }
    public DateTime DateTime { get; private set; }
    public long MovieId { get; private set; }
    public Movie? Movie { get; private set; }
    public long RoomId { get; private set; }
    public Room? Room { get; private set; }
    public decimal Price { get; private set; }
    public IList<SessionSeat> Seats { get; private set; }

    #endregion
    
    #region Constructors

    public Session(DateTime dateTime, long movieId, long roomId, decimal price)
    {
        Id = 0;
        Seats = new List<SessionSeat>();
        Update(dateTime, movieId, roomId, price);
    }

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