using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Auth.Command.RevokeAll;

public class RevokeAllCommandRequest : IRequest<Response<string>>
{
}


