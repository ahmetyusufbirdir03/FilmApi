using AutoMapper;
using FilmApi.Application.Bases;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Application.Features.Auth.Command.RevokeAll;

public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Response<string>>
{
    private readonly UserManager<User> userManager;

    public RevokeAllCommandHandler(
        UserManager<User> userManager,
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
    }

    public async Task<Response<string>> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
    {
        List<User> users = await userManager.Users.ToListAsync(cancellationToken);

        foreach(User user in users)
        {
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
        }
        return Response<string>.Success("", "All users are revoked successfully!", StatusCodes.Status200OK);
    }
}


