using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Services;

public interface ISessionSeatService : IBaseService<SessionSeat>
{
    Task<SessionSeat> AddAsync(SessionSeat movie);
    Task<SessionSeat> UpdateAsync(SessionSeat movie);
    Task<bool> ReserveAsync(long id, string documentId);
    Task<bool> CancelReserveAsync(long id);
    Task<bool> ConfirmAsync(long id);
    Task<bool> CancelConfirmationAsync(long id);
}