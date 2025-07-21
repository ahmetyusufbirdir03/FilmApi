using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Movies.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQueryRequest, IList<GetAllMoviesQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;    
    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<IList<GetAllMoviesQueryResponse>> Handle(GetAllMoviesQueryRequest request, CancellationToken cancellationToken)
    {
        var movies = await unitOfWork.GetGenericRepository<Movie>().GetAllAsync();

        var response = mapper.Map<IList<GetAllMoviesQueryResponse>>(movies);
        return response;    

    }
}
