using AutoMapper;
using FilmApi.Application.Bases;
using FilmApi.Application.Features.Auth.Rules;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Application.Tokens;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FilmApi.Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandHandler : BaseHandler,IRequestHandler<RefreshTokenCommandRequest, Response<RefreshTokenCommandResponse>>
{
    private readonly UserManager<User> userManager;
    private readonly ITokenService tokenService;
    private readonly AuthRules authRules;

    public RefreshTokenCommandHandler(
        IMapper mapper,
        UserManager<User> userManager,
        ITokenService tokenService,
        AuthRules authRules,
        IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
        this.authRules = authRules;
    }

    public async Task<Response<RefreshTokenCommandResponse>> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        string email = principal.FindFirstValue(ClaimTypes.Email);

        User? user = await userManager.FindByEmailAsync(email);
        IList<string> roles = await userManager.GetRolesAsync(user);

        await authRules.SessionShouldNotBeExpired(user.RefreshTokenExpiryTime);

        JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
        string newRefreshToken = tokenService.GenerateRefrewshToken();

        user.RefreshToken = newRefreshToken;
        await userManager.UpdateAsync(user);

        return Response<RefreshTokenCommandResponse>.Success(new()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken
        },"Tokens are created successfully!", StatusCodes.Status200OK);

    }
}

