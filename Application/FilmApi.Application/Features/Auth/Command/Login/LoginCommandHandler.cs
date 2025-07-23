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
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace FilmApi.Application.Features.Auth.Command.Login;

public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, Response<LoginCommandResponse>>
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;
    private readonly AuthRules authRules;
    private readonly IConfiguration configuration;
    private readonly ITokenService tokenService;

    public LoginCommandHandler(UserManager<User> userManager, 
        RoleManager<Role> roleManager, 
        ITokenService tokenService, 
        AuthRules authRules, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.authRules = authRules;
        this.configuration = configuration;
        this.tokenService = tokenService;
    }

    public async Task<Response<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await userManager.FindByEmailAsync(request.Email);
        bool cheackPassword = await userManager.CheckPasswordAsync(user, request.Password);

        await authRules.EmailOrPasswordShouldNotBeExist(user, cheackPassword);

        IList<string> roles = await userManager.GetRolesAsync(user);

        JwtSecurityToken token = await tokenService.CreateToken(user, roles);
        string refreshToken = tokenService.GenerateRefrewshToken();

        _ = int.TryParse(
            configuration["JWT:RefreshTokenValidityInDays"], out int refteshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refteshTokenValidityInDays);
        
        await userManager.UpdateAsync(user);
        await userManager.UpdateSecurityStampAsync(user);

        string _token = new JwtSecurityTokenHandler().WriteToken(token);

        await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

        return Response<LoginCommandResponse>.Success(new()
        {
            Token = _token,
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        },"Token is created successfully!",StatusCodes.Status200OK);
    }
}
