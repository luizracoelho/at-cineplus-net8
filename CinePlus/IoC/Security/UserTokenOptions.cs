namespace CinePlus.IoC.Security;

public static class UserTokenOptions
{
    public const string SaltKey = "12345678";
    public const string ValidIssuer = "cine-plus.com.br";
    public const string ValidAudience = "cine-plus.com.br";
    public const string IssuerSigningKey = "12345678123456781234567812345678";
}