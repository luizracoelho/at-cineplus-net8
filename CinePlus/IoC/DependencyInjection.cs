using CinePlus.APP;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Context;
using CinePlus.Domain.Contracts.Repos;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Services;
using CinePlus.Domain.Validators;
using CinePlus.Infra.Context;
using CinePlus.Infra.Repos;
using CinePlus.IoC.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var host = config["DB:HOST"];
        var port = config["DB:PORT"];
        var user = config["DB:USER"];
        var password = config["DB:PASSWORD"];
        var database = config["DB:DATABASE"];

        var connectionString =
            $"server={host};port={port};userid={user};pwd={password};database={database};default command timeout=0;";

        services.AddDbContext<DataContext>(options =>
        {
            options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    x => { x.MigrationsAssembly(typeof(DataContext).Assembly.FullName); })
                .LogTo(Console.WriteLine, LogLevel.Information);
        });

        services.AddAutoMapper(cfg => cfg.AddProfile<MapProfile>());

        services.AddScoped<IDataContext, DataContext>();

        // Add Applications
        services.AddScoped<IMovieApp, MovieApp>();
        services.AddScoped<IRoomApp, RoomApp>();
        services.AddScoped<ISessionApp, SessionApp>();

        // Add Services
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<ISessionSeatService, SessionSeatService>();

        // Add Repositories
        services.AddScoped<IMovieRepo, MovieRepo>();
        services.AddScoped<IRoomRepo, RoomRepo>();
        services.AddScoped<ISessionRepo, SessionRepo>();
        services.AddScoped<ISessionSeatRepo, SessionSeatRepo>();

        // Add Validators
        services.AddScoped<MovieValidator>();
        services.AddScoped<RoomValidator>();
        services.AddScoped<SessionValidator>();
        services.AddScoped<SessionSeatValidator>();

        return services;
    }
}