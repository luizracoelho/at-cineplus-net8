namespace CinePlus.Domain.Models;

public class Room(string name, int rowsCount, int seatsByRow)
{
    #region Properties

    public long Id { get; private set; } = 0;
    public string Name { get; private set; } = name;
    public int RowsCount { get; private set; } = rowsCount;
    public int SeatsByRow { get; private set; } = seatsByRow;
    public bool Active { get; private set; } = true;
    public IList<Session> Sessions { get; private set; } = [];

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