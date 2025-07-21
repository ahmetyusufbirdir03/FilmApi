using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Movies.Queries.GetMovieById;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQueryRequest,
    GetMovieByIdQueryResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetMovieByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<GetMovieByIdQueryResponse> Handle(GetMovieByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.GetGenericRepository<Movie>().GetByIdAsync(request.Id);

        var response = mapper.Map<GetMovieByIdQueryResponse>(movie);
        return response;
    }
}

