using Microsoft.AspNetCore.Identity;
namespace FilmApi.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

}
