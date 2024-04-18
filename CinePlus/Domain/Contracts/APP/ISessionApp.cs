using CinePlus.Domain.ViewModels.Sessions;
using CinePlus.Domain.ViewModels.SessionSeats;

namespace CinePlus.Domain.Contracts.APP;

public interface ISessionApp
{
    Task<IList<SessionVm>> ListAsync();
    Task<IList<SessionVm>> ListByMovieAndRoomAsync(long movieId, long roomId);
    Task<SessionVm> FindAsync(long id);
    Task<SessionVm> AddAsync(CreateSessionVm vm);
    Task<SessionVm> UpdateAsync(long id, CreateSessionVm vm);
    Task<bool> RemoveAsync(long id);
    Task<SessionSeatVm> AddSeatAsync(long sessionId, CreateSessionSeatVm vm);
    Task<SessionSeatVm> UpdateSeatAsync(long sessionId, long id, CreateSessionSeatVm vm);
    Task<bool> RemoveSeatAsync(long sessionId, long id);
    Task<bool> ReserveSeatAsync(long sessionId, long id, ReserveSessionSeatVm vm);
    Task<bool> CancelReserveSeatAsync(long sessionId, long id);
    Task<bool> ConfirmReserveSeatAsync(long sessionId, long id);
    Task<bool> CancelConfirmationSeatAsync(long sessionId, long id);
}