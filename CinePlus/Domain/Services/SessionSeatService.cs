using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Validators;
using CinePlus.Infra.Repos;
using FluentValidation;

namespace CinePlus.Domain.Services;

public class SessionSeatService : BaseService<SessionSeat>, ISessionSeatService
{
    private readonly ISessionSeatRepo _repo;
    private readonly SessionSeatValidator _validator;

    public SessionSeatService(ISessionSeatRepo repo, SessionSeatValidator validator) : base(repo)
    {
        _repo = repo;
        _validator = validator;
    }

    public async Task<SessionSeat> AddAsync(SessionSeat seat)
    {
        await _validator.ValidateAndThrowAsync(seat);
        return await _repo.AddAsync(seat);
    }

    public async Task<SessionSeat> UpdateAsync(SessionSeat seat)
    {
        var seatDb = await FindAsync(seat.Id);

        seatDb.Update(seat.Seat);

        await _validator.ValidateAndThrowAsync(seatDb);

        return await _repo.UpdateAsync(seatDb);
    }
    
    public async Task<bool> ReserveAsync(long id, string documentId)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Reserve(documentId);

        if (!result) throw new Exception("Não foi possível reservar o assento, pois ele já se encontra reservado.");

        await _repo.UpdateAsync(movieDb);

        return true;
    }

    public async Task<bool> CancelReserveAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.CancelReserve();

        if (!result) throw new Exception("Não foi possível cancelar a reserva, pois ele já se encontra cancelada.");

        await _repo.UpdateAsync(movieDb);

        return true;
    }
    
    public async Task<bool> ConfirmAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.Confirm();

        if (!result) throw new Exception("Não foi possível confirmar o assento, pois ele não se encontra reservado.");

        await _repo.UpdateAsync(movieDb);

        return true;
    }
    
    public async Task<bool> CancelConfirmationAsync(long id)
    {
        var movieDb = await FindAsync(id);
        var result = movieDb.CancelConfirmation();

        if (!result) throw new Exception("Não foi possível cancelar a confirmação, pois ele já se encontra cancelada.");

        await _repo.UpdateAsync(movieDb);

        return true;
    }
}