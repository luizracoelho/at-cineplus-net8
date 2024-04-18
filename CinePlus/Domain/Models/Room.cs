namespace CinePlus.Domain.Models;

public class Room
{
    #region Properties

    public long Id { get; private set; }
    public string Name { get; private set; }
    public int RowsCount { get; private set; }
    public int SeatsByRow { get; private set; }
    public bool Active { get; private set; }
    public IList<Session> Sessions { get; private set; }

    #endregion

    #region Constructors

    public Room(string name, int rowsCount, int seatsByRow)
    {
        Id = 0;
        Active = true;
        Sessions = new List<Session>();
        Update(name, rowsCount, seatsByRow);
    }

    #endregion

    #region Methods

    public void Update(string name, int rowsCount, int seatsByRow)
    {
        Name = name;
        RowsCount = rowsCount;
        SeatsByRow = seatsByRow;
    }

    public bool Activate()
    {
        if (Active == true) return false;

        Active = true;
        return true;
    }

    public bool Deactivate()
    {
        if (Active == false) return false;

        Active = false;
        return true;
    }

    public override string ToString() => $"[{Id}] {Name}";

    #endregion
}