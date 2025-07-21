using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
    {
        var movie = mapper.Map<Movie>(request);
        await unitOfWork.GetGenericRepository<Movie>().CreateAsync(movie);
        return new CreateMovieCommandResponse()
        {
            Title = movie.Title,
            Description = movie.Description,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre,
        };
    }
}
