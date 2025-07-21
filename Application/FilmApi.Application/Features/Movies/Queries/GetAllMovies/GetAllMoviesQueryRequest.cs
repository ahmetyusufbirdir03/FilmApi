using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Movies.Queries.GetAllMovies;

public class GetAllMoviesQueryRequest : IRequest<IList<GetAllMoviesQueryResponse>>
{

}

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQueryRequest, IList<GetAllMoviesQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork)
    {
         this.unitOfWork = unitOfWork;
    }
    public async Task<IList<GetAllMoviesQueryResponse>> Handle(GetAllMoviesQueryRequest request, CancellationToken cancellationToken)
    {
        var movies = await unitOfWork.GetGenericRepository<Movie>().GetAllAsync();

        List<GetAllMoviesQueryResponse> response = new();

        foreach (var movie in movies)
        {
            response.Add(new GetAllMoviesQueryResponse
            {
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description,
                Genre = movie.Genre,
            });
        }
        
        return response;

    }
}
