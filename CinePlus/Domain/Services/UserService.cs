using CinePlus.Domain.Contracts.Services;
using CinePlus.Domain.Exceptions;
using CinePlus.Domain.Models;
using CinePlus.IoC.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinePlus.Domain.Services;

public class UserService(UserManager<User> userManager, SignInManager<User> signInManager) : IUserService
{
    public async Task<IList<User>> ListAsync()
        => await userManager.Users.OrderBy(x => x.UserName).ToListAsync();

    public async Task<User> FindAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user == null) throw new NotFoundException();

        return user;
    }

    public async Task<User> AddAsync(User user, string password)
    {
        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var exceptions = result.Errors.Select(x => new Exception(x.Description));
            throw new AggregateException(exceptions);
        }

        // Adicionar ele a uma role padrão
        await userManager.AddToRoleAsync(user, UserRoles.Customer);

        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            var exceptions = result.Errors.Select(x => new Exception(x.Description));
            throw new AggregateException(exceptions);
        }

        return user;
    }

    public async Task<(User, string, DateTime)> LoginAsync(string email, string password)
    {
        // Encontrar um usuário pelo e-mail
        var user = await userManager.FindByEmailAsync(email);

        // Verificar se o usuário existe na base de dados
        if (user == null) throw new Exception("Usuário ou senha incorretos.");

        // Verificar se a senha informada corresponde a senha do usuário
        var result = await signInManager.PasswordSignInAsync(user, password, false, false);
        if (!result.Succeeded) throw new Exception("Usuário ou senha incorretos.");

        // Gerar o token de acesso
        var roles = await userManager.GetRolesAsync(user);
        var (token, validTo) = user.GenerateToken(roles);

        return (user, token, validTo);
    }
}