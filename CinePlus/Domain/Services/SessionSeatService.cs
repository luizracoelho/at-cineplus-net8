using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Validators;
using CinePlus.Infra.Repos;
using FluentValidation;

namespace CinePlus.Domain.Services;

public class SessionSeatService(ISessionSeatRepo repo, SessionSeatValidator validator) : BaseService<SessionSeat>(repo), ISessionSeatService
{
    public async Task<SessionSeat> AddAsync(SessionSeat seat)
    {
        await validator.ValidateAndThrowAsync(seat);
        return await repo.AddAsync(seat);
    }

    public async Task<SessionSeat> UpdateAsync(SessionSeat seat)
    {
        var seatDb = await FindAsync(seat.Id);

        seatDb.Update(seat.Seat);

        await validator.ValidateAndThrowAsync(seatDb);

        return await repo.UpdateAsync(seatDb);
    }
    
    public async Task<bool> ReserveAsync(long id, Guid userId)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Reserve(userId);

        if (!result) throw new Exception("Não foi possível reservar o assento, pois ele já se encontra reservado.");

        await repo.UpdateAsync(movieDb);

        return true;
    }

    public async Task<bool> CancelReserveAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.CancelReserve();

        if (!result) throw new Exception("Não foi possível cancelar a reserva, pois ele já se encontra cancelada.");

        await repo.UpdateAsync(movieDb);

        return true;
    }
    
    public async Task<bool> ConfirmAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Confirm();

        if (!result) throw new Exception("Não foi possível confirmar o assento, pois ele não se encontra reservado.");

        await repo.UpdateAsync(movieDb);

        return true;
    }
    
    public async Task<bool> CancelConfirmationAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.CancelConfirmation();

        if (!result) throw new Exception("Não foi possível cancelar a confirmação, pois ele já se encontra cancelada.");

        await repo.UpdateAsync(movieDb);

        return true;
    }
}