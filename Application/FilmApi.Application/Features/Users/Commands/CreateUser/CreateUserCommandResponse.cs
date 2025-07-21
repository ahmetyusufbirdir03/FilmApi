namespace FilmApi.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandResponse
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
}