using MediatR;

namespace FilmApi.Application.Features.Movies.Queries.GetAllMovies;

public class GetAllMoviesQueryRequest : IRequest<IList<GetAllMoviesQueryResponse>>
{

}
