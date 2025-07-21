using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, string>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user = await unitOfWork.GetGenericRepository<AppUser>().GetByIdAsync(request.Id);
        if(user is null)
        {
            return "User could not found!";
        }

        await unitOfWork.GetGenericRepository<AppUser>().DeleteAsync(user);
        await unitOfWork.SaveChangesAsync();
        return "User is deleted successfully!";
    }
}