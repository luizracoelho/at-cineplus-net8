using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.ViewModels.Sessions;
using CinePlus.Domain.ViewModels.SessionSeats;

namespace CinePlus.APP;

public class SessionApp : ISessionApp
{
    private readonly ISessionService _service;
    private readonly ISessionSeatService _seatService;
    private readonly IMapper _mapper;

    public SessionApp(
        ISessionService service,
        ISessionSeatService seatService,
        IMapper mapper
    )
    {
        _service = service;
        _seatService = seatService;
        _mapper = mapper;
    }

    public async Task<IList<SessionVm>> ListAsync()
    {
        var sessions = await _service.ListAsync();
        return _mapper.Map<IList<SessionVm>>(sessions);
    }

    public async Task<IList<SessionVm>> ListByMovieAndRoomAsync(long movieId, long roomId)
    {
        var sessions = await _service.ListByMovieAndRoomAsync(movieId, roomId);
        return _mapper.Map<IList<SessionVm>>(sessions);
    }

    public async Task<SessionVm> FindAsync(long id)
    {
        var session = await _service.FindAsync(id);
        return _mapper.Map<SessionVm>(session);
    }

    public async Task<SessionVm> AddAsync(CreateSessionVm vm)
    {
        var session = new Session(vm.DateTime, vm.MovieId, vm.RoomId, vm.Price);
        await _service.AddAsync(session);

        return _mapper.Map<SessionVm>(session);
    }

    public async Task<SessionVm> UpdateAsync(long id, CreateSessionVm vm)
    {
        var session = await _service.FindAsync(id);

        session.Update(vm.DateTime, vm.MovieId, vm.RoomId, vm.Price);
        await _service.UpdateAsync(session);

        return _mapper.Map<SessionVm>(session);
    }

    public async Task<bool> RemoveAsync(long id)
        => await _service.RemoveAsync(id);

    public async Task<SessionSeatVm> AddSeatAsync(long sessionId, CreateSessionSeatVm vm)
    {
        var seat = new SessionSeat(vm.Seat, sessionId);
        await _seatService.AddAsync(seat);

        return _mapper.Map<SessionSeatVm>(seat);
    }

    public async Task<SessionSeatVm> UpdateSeatAsync(long sessionId, long id, CreateSessionSeatVm vm)
    {
        var seat = await FindAndValidateSeatAsync(sessionId, id);
        seat.Update(vm.Seat);

        await _seatService.UpdateAsync(seat);

        return _mapper.Map<SessionSeatVm>(seat);
    }

    public async Task<bool> RemoveSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await _seatService.RemoveAsync(id);
    }

    public async Task<bool> ReserveSeatAsync(long sessionId, long id, ReserveSessionSeatVm vm)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await _seatService.ReserveAsync(id, vm.Document);
    }

    public async Task<bool> CancelReserveSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await _seatService.CancelReserveAsync(id);
    }

    public async Task<bool> ConfirmReserveSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await _seatService.ConfirmAsync(id);
    }

    public async Task<bool> CancelConfirmationSeatAsync(long sessionId, long id)
    {
        await FindAndValidateSeatAsync(sessionId, id);
        return await _seatService.CancelConfirmationAsync(id);
    }

    private async Task<SessionSeat> FindAndValidateSeatAsync(long sessionId, long seatId)
    {
        var seat = await _seatService.FindAsync(seatId);

        if (sessionId != seat.SessionId)
            throw new Exception("Este assento não pertence a esta seção.");

        return seat;
    }
}