namespace CinePlus.Domain.ViewModels.Users;

public class LoggedInUserVm : UserVm
{
    public required string Token { get; set; }
    public DateTime ValidTo { get; set; }
}