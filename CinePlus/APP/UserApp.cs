using AutoMapper;
using CinePlus.Domain.Contracts.APP;
using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Models;
using CinePlus.Domain.ViewModels.Users;

namespace CinePlus.APP;

public class UserApp(IUserService service, IMapper mapper) : IUserApp
{
    public async Task<IList<UserVm>> ListAsync()
    {
        var users = await service.ListAsync();
        var usersVm = mapper.Map<IList<UserVm>>(users);
        return usersVm;
    }

    public async Task<UserVm> FindAsync(Guid id)
    {
        var user = await service.FindAsync(id);
        var userVm = mapper.Map<UserVm>(user);
        return userVm;
    }

    public async Task<UserVm> AddAsync(CreateUserVm vm)
    {
        var user = new User(vm.UserName, vm.Email, vm.Document);
        await service.AddAsync(user, vm.Password);

        var userVm = mapper.Map<UserVm>(user);

        return userVm;
    }

    public async Task<UserVm> UpdateAsync(Guid id, CreateUserVm vm)
    {
        var user = await service.FindAsync(id);

        user.Update(vm.UserName, vm.Email, vm.Document);
        await service.UpdateAsync(user);

        var userVm = mapper.Map<UserVm>(user);

        return userVm;
    }

    public async Task<LoggedInUserVm> LoginAsync(LoginVm login)
    {
        var (user, token, validTo) = await service.LoginAsync(login.Email, login.Password);

        var userVm = mapper.Map<LoggedInUserVm>(user);

        userVm.Token = token;
        userVm.ValidTo = validTo;

        return userVm;
    }
}