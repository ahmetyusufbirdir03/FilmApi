using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandRequest : IRequest<string>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, string>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        User? user = await unitOfWork.GetGenericRepository<User>().GetByIdAsync(request.Id);
        if (user is null) 
        { 
            return "User could not be found!"; 
        }

        mapper.Map(request, user);
        await unitOfWork.GetGenericRepository<User>().UpdateAsync(user);
        await unitOfWork.SaveChangesAsync();
        return "User is updated successfully!";

    }
}
