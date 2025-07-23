using AutoMapper;
using FilmApi.Application.Bases;
using FilmApi.Application.Features.Auth.Rules;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FilmApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Response<string>>
{
    private readonly UserManager<User> userManager;
    private readonly AuthRules authRules;

    public RevokeCommandHandler(
        UserManager<User> userManager,
        AuthRules authRules,
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.authRules = authRules;
    }

    public async Task<Response<string>> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByNameAsync(request.Email);
        await authRules.EmailAdressShouldBeValid(user);

        user.RefreshToken = null;
        await userManager.UpdateAsync(user);

        return Response<string>.Success("", "User is revoked successfully!", StatusCodes.Status200OK);
    }
}


