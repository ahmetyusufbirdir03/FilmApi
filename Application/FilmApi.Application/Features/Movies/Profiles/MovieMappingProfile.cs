using AutoMapper;
using FilmApi.Application.Features.Movies.Commands.CreateMovie;
using FilmApi.Application.Features.Movies.Commands.UpdateMovie;
using FilmApi.Application.Features.Movies.Queries.GetAllMovies;
using FilmApi.Application.Features.Movies.Queries.GetMovieById;
using FilmApi.Domain.Entities;

public class MovieMappingProfile : Profile
{
    public MovieMappingProfile()
    {
        CreateMap<Movie, GetAllMoviesQueryResponse>();
        CreateMap<Movie, GetMovieByIdQueryRequest>();
        CreateMap<CreateMovieCommandRequest, Movie>();
        CreateMap<UpdateMovieCommandRequest, Movie>();
    }
}
