using MediatR;

namespace FilmApi.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandRequest : IRequest<string>
{
    public Guid Id { get; set; }
}
