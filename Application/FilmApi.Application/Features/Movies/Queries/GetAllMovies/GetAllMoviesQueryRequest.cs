using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Movies.Queries.GetAllMovies;

public class GetAllMoviesQueryRequest : IRequest<Response<IList<GetAllMoviesQueryResponse>>>
{

}
