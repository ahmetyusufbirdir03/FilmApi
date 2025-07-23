using AutoMapper;
using FilmApi.Application.Bases;
using FilmApi.Application.DTOs;
using FilmApi.Application.Features.Auth.Rules;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FilmApi.Application.Features.Auth.Command.Register;

public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Response<UserDto>>
{
    private readonly AuthRules authRules;
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;
    public RegisterCommandHandler(AuthRules authRules, 
        UserManager<User> userManager, 
        RoleManager<Role> roleManager ,
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.authRules = authRules;
        this.roleManager = roleManager;
        this.userManager = userManager;    
    }

    public async Task<Response<UserDto>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

        User user = mapper.Map<User>(request);
        user.UserName = request.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();

        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if(result.Succeeded)
        {
            if (!await roleManager.RoleExistsAsync("user"))
                await roleManager.CreateAsync(new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });
            await userManager.AddToRoleAsync(user, "user");
        }
        UserDto _user = mapper.Map<UserDto>(user);
        return Response<UserDto>.Success(_user, "User is created successfully!", StatusCodes.Status200OK);
    }
}
