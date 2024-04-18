using CinePlus.Domain.Enums;

namespace CinePlus.Domain.Models;

public class SessionSeat
{
    #region Properties

    public long Id { get; private set; }
    public string Seat { get; private set; }
    public SessionSeatStatus Status { get; private set; }
    public long SessionId { get; private set; }
    public Session? Session { get; private set; }
    public string? Document { get; private set; }

    #endregion
    
    #region Constructors

    public SessionSeat(string seat, long sessionId)
    {
        Id = 0;
        SessionId = sessionId;
        Status = SessionSeatStatus.Available;
        Update(seat);
    }

    #endregion
    
    #region Methods

    public void Update(string seat) => Seat = seat;

    public bool Reserve(string document)
    {
        if (Status != SessionSeatStatus.Available) return false;

        Document = document;
        Status = SessionSeatStatus.Reserved;
        return true;
    }

    public bool CancelReserve()
    {
        if (Status != SessionSeatStatus.Reserved) return false;

        Document = null;
        Status = SessionSeatStatus.Available;
        return true;
    }

    public bool Confirm()
    {
        if (Status != SessionSeatStatus.Reserved) return false;

        Status = SessionSeatStatus.Confirmed;
        return true;
    }

    public bool CancelConfirmation()
    {
        if (Status != SessionSeatStatus.Confirmed) return false;

        Document = null;
        Status = SessionSeatStatus.Available;
        return true;
    }

    public void NullSession() => Session = null;
    
    public override string ToString() => $"[{Id}] Seat: {Seat} | Status: {Status}";

    #endregion
}