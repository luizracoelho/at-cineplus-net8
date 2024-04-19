using CinePlus.Domain.Enums;

namespace CinePlus.Domain.Models;

public class SessionSeat(string seat, long sessionId)
{
    #region Properties

    public long Id { get; private set; }
    public string Seat { get; private set; } = seat;
    public SessionSeatStatus Status { get; private set; } = SessionSeatStatus.Available;
    public long SessionId { get; private set; } = sessionId;
    public Session? Session { get; private set; }
    public string? Document { get; private set; }

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