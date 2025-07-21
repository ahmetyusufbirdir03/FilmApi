using MediatR;

namespace FilmApi.Application.Features.Movies.Queries.GetMovieById;

public class GetMovieByIdQueryRequest : IRequest<GetMovieByIdQueryResponse>
{
    public Guid Id { get; set; }  // Sorgulanacak filmin ID'si
}

