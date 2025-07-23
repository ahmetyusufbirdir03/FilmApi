using FilmApi.Application.DTOs;
using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Auth.Command.Register;

public class RegisterCommandRequest : IRequest<Response<UserDto>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
