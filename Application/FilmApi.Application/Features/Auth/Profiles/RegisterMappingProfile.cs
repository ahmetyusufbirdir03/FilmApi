using AutoMapper;
using FilmApi.Application.DTOs;
using FilmApi.Application.Features.Auth.Command.Register;
using FilmApi.Domain.Entities;

namespace FilmApi.Application.Features.Auth.Profiles
{
    public class RegisterMappingProfile : Profile
    {
        public RegisterMappingProfile()
        {
            CreateMap<RegisterCommandRequest, User>();
            CreateMap<User, UserDto>();
        }
    }
}
