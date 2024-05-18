using CinePlus.Domain.Models;

namespace CinePlus.Domain.Contracts.Services;

public interface IUserService
{
    Task<IList<User>> ListAsync();
    Task<User> FindAsync(Guid id);
    Task<User> AddAsync(User user, string password);
    Task<User> UpdateAsync(User user);
    Task<(User, string, DateTime)> LoginAsync(string email, string password);
}