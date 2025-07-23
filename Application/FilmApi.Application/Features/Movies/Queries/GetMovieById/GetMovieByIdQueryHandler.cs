using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FilmApi.Application.Features.Movies.Queries.GetMovieById;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQueryRequest,
    Response<GetMovieByIdQueryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetMovieByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<Response<GetMovieByIdQueryResponse>> Handle(GetMovieByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.GetGenericRepository<Movie>().GetByIdAsync(request.Id);

        var response = mapper.Map<GetMovieByIdQueryResponse>(movie);
        return Response<GetMovieByIdQueryResponse>.Success(response,"Movie is brought successfully!",StatusCodes.Status200OK);
    }
}

