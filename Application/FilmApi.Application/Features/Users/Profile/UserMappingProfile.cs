using AutoMapper;
using FilmApi.Application.Features.Users.Commands.CreateUser;
using FilmApi.Application.Features.Users.Commands.UpdateUser;
using FilmApi.Application.Features.Users.Queries.GetAllUsers;
using FilmApi.Application.Features.Users.Queries.GetUserById;
using FilmApi.Domain.Entities;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserCommandRequest, User>();
        CreateMap<UpdateUserCommandRequest, User>();
        CreateMap<User, GetAllUsersQueryResponse>();
        CreateMap<User, GetUserByIdQueryResponse>();
    }
}

