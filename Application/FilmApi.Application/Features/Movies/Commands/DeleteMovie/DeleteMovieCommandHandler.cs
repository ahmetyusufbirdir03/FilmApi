using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Application.Response;
using FilmApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FilmApi.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommandRequest, Response<string>>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<Response<string>> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
    {
        Movie? movie = await unitOfWork.GetGenericRepository<Movie>().GetByIdAsync(request.Id);
        if(movie is null)
        {
            return Response<string>.Failure("Movie could not be found!", StatusCodes.Status404NotFound);
        }

        await unitOfWork.GetGenericRepository<Movie>().DeleteAsync(movie);
        await unitOfWork.SaveChangesAsync();

        return Response<string>.Failure("Movie is deleted successfully!", StatusCodes.Status200OK);
    }
}