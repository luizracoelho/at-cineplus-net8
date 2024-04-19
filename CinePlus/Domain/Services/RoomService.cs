using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.Validators;
using FluentValidation;

namespace CinePlus.Domain.Services;

public class RoomService(IRoomRepo repo, RoomValidator validator) : BaseService<Room>(repo), IRoomService
{
    public async Task<IList<Room>> ListActivesAsync() 
        => await repo.ListActivesAsync();

    public async Task<Room> AddAsync(Room room)
    {
        await validator.ValidateAndThrowAsync(room);
        return await repo.AddAsync(room);
    }

    public async Task<Room> UpdateAsync(Room room)
    {
        var roomDb = await FindAsync(room.Id);

        roomDb.Update(room.Name, room.RowsCount, room.SeatsByRow);

        await validator.ValidateAndThrowAsync(roomDb);

        return await repo.UpdateAsync(roomDb);
    }
    
    public async Task<bool> ActivateAsync(long id)
    {
        var roomDb = await FindAsync(id);
        var result = roomDb.Activate();

        if (!result) throw new Exception("Não foi possível ativar a sala, pois ela já se encontra ativa.");

        await repo.UpdateAsync(roomDb);

        return true;
    }

    public async Task<bool> DeactivateAsync(long id)
    {
        var roomDb = await FindAsync(id);
        var result = roomDb.Deactivate();

        if (!result) throw new Exception("Não foi possível desativar a sala, pois ela já se encontra inativa.");

        await repo.UpdateAsync(roomDb);

        return true;
    }
}