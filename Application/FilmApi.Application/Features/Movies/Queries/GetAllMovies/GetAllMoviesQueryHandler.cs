using AutoMapper;
using FilmApi.Application.Response;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FilmApi.Application.Features.Movies.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQueryRequest, Response<IList<GetAllMoviesQueryResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;    
    public GetAllMoviesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<Response<IList<GetAllMoviesQueryResponse>>> Handle(GetAllMoviesQueryRequest request, CancellationToken cancellationToken)
    {
        var movies = await unitOfWork.GetGenericRepository<Movie>().GetAllAsync();

        var response = mapper.Map<IList<GetAllMoviesQueryResponse>>(movies);
        return Response<IList<GetAllMoviesQueryResponse>>.Success(response,"Movies are brought successfully!",StatusCodes.Status200OK);
        //throw new Exception("HATA MESAJI");

    }
}
