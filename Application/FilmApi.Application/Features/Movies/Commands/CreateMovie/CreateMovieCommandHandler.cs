using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FilmApi.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, Response<CreateMovieCommandResponse>>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<Response<CreateMovieCommandResponse>> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
    {
        var movie = mapper.Map<Movie>(request);
        await unitOfWork.GetGenericRepository<Movie>().CreateAsync(movie);
        return Response<CreateMovieCommandResponse>.Success(new CreateMovieCommandResponse()
        {
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre,
        },"Movie is created successfully!",StatusCodes.Status200OK);
    }
}
