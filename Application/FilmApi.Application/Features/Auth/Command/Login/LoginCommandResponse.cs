namespace FilmApi.Application.Features.Auth.Command.Login;

public class LoginCommandResponse
{
    public String Token { get; set; }
    public String RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
}
