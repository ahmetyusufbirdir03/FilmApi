using FilmApi.Application.Response;
using MediatR;
using System.ComponentModel;

namespace FilmApi.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<Response<LoginCommandResponse>>
{
    [DefaultValue("ahmet@mail.com")]
    public String Email { get; set; }

    [DefaultValue("1234567")]
    public String Password { get; set; }
}
