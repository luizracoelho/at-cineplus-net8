using CinePlus.Domain.ViewModels.Users;

namespace CinePlus.Domain.Contracts.APP;

public interface IUserApp
{
    Task<IList<UserVm>> ListAsync();
    Task<UserVm> FindAsync(Guid id);
    Task<UserVm> AddAsync(CreateUserVm vm);
    Task<UserVm> UpdateAsync(Guid id, CreateUserVm vm);
    Task<LoggedInUserVm> LoginAsync(LoginVm login);
}