using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandRequest : IRequest<Response<string>>
{
    public string Email { get; set; }
}


