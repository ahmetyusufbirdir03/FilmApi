using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FilmApi.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommandRequest, Response<string>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<Response<string>> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.GetGenericRepository<Movie>().GetByIdAsync(request.Id);

        if (movie == null)
            return Response<string>.Failure("Movie could not be found!", StatusCodes.Status404NotFound);

        mapper.Map(request, movie);

        await unitOfWork.GetGenericRepository<Movie>().UpdateAsync(movie);
        await unitOfWork.SaveChangesAsync();
        return Response<string>.Failure("Movie is updated successfully!", StatusCodes.Status200OK);
    }
}