using AutoMapper;
using CinePlus.Domain.Models;
using CinePlus.Domain.ViewModels.Movies;
using CinePlus.Domain.ViewModels.Rooms;
using CinePlus.Domain.ViewModels.Sessions;
using CinePlus.Domain.ViewModels.SessionSeats;

namespace CinePlus.IoC.Mappers;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Movie, MovieVm>().ReverseMap();
        CreateMap<Room, RoomVm>().ReverseMap();
        CreateMap<Session, SessionVm>().ReverseMap();     
        CreateMap<SessionSeat, SessionSeatVm>().ReverseMap();
    }
}