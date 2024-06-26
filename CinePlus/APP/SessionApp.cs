using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.ViewModels.Sessions;
using CinePlus.Domain.ViewModels.SessionSeats;

namespace CinePlus.APP;

public class SessionApp(ISessionService service, ISessionSeatService seatService, IMapper mapper) : ISessionApp
{
    public async Task<IList<SessionVm>> ListAsync()
    {
        var sessions = await service.ListAsync();
        return mapper.Map<IList<SessionVm>>(sessions);
    }

    public async Task<IList<SessionVm>> ListByMovieAndRoomAsync(long movieId, long roomId)
    {
        var sessions = await service.ListByMovieAndRoomAsync(movieId, roomId);
        return mapper.Map<IList<SessionVm>>(sessions);
    }

    public async Task<SessionVm> FindAsync(long id)
    {
        var session = await service.FindAsync(id);
        return mapper.Map<SessionVm>(session);
    }

    public async Task<SessionVm> AddAsync(CreateSessionVm vm)
    {
        var session = new Session(vm.DateTime, vm.MovieId, vm.RoomId, vm.Price);
        await service.AddAsync(session);

        return mapper.Map<SessionVm>(session);
    }

    public async Task<SessionVm> UpdateAsync(long id, CreateSessionVm vm)
    {
        var session = await service.FindAsync(id);

        session.Update(vm.DateTime, vm.MovieId, vm.RoomId, vm.Price);
        await service.UpdateAsync(session);

        return mapper.Map<SessionVm>(session);
    }

    public async Task<bool> RemoveAsync(long id)
        => await service.RemoveAsync(id);

    public async Task<SessionSeatVm> AddSeatAsync(long sessionId, CreateSessionSeatVm vm)
    {
        var seat = new SessionSeat(vm.Seat, sessionId);
        await seatService.AddAsync(seat);

        return mapper.Map<SessionSeatVm>(seat);
    }

    public async Task<SessionSeatVm> UpdateSeatAsync(long sessionId, long id, CreateSessionSeatVm vm)
    {
        var seat = await FindAndValidateSeatAsync(sessionId, id);
        seat.Update(vm.Seat);

        await seatService.UpdateAsync(seat);

        return mapper.Map<SessionSeatVm>(seat);
    }

    public async Task<bool> RemoveSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await seatService.RemoveAsync(id);
    }

    public async Task<bool> ReserveSeatAsync(long sessionId, long id, ReserveSessionSeatVm vm)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await seatService.ReserveAsync(id, vm.UserId);
    }

    public async Task<bool> CancelReserveSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await seatService.CancelReserveAsync(id);
    }

    public async Task<bool> ConfirmReserveSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await seatService.ConfirmAsync(id);
    }

    public async Task<bool> CancelConfirmationSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await seatService.CancelConfirmationAsync(id);
    }

    private async Task<SessionSeat> FindAndValidateSeatAsync(long sessionId, long seatId)
    {
        var seat = await seatService.FindAsync(seatId);

        if (sessionId != seat.SessionId)
            throw new Exception("Este assento não pertence a esta seção.");

        return seat;
    }
}