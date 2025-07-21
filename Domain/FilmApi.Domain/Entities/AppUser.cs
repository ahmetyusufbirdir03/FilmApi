using Microsoft.AspNetCore.Identity;
namespace FilmApi.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    }
}
