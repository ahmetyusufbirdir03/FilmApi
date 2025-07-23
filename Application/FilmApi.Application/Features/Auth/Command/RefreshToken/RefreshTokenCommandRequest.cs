using FilmApi.Application.Features.Auth.Exceptions;
using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandRequest : IRequest<Response<RefreshTokenCommandResponse>>
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

