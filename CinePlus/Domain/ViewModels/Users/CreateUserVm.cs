namespace CinePlus.Domain.ViewModels.Users;

public class CreateUserVm
{
    public required string Document { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}