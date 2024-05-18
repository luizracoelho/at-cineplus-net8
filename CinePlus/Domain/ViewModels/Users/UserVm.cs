namespace CinePlus.Domain.ViewModels.Users;

public class UserVm
{
    public Guid Id { get; set; }
    public required string Document { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
}