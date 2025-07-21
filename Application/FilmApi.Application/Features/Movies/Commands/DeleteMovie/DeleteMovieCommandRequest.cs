using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmApi.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandRequest : IRequest<string>
{
    public Guid Id { get; set; }  // Silinecek filmin ID'si
}

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommandRequest, string>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(DeleteMovieCommandRequest request, CancellationToken cancellationToken)
    {
        Movie? movie = await unitOfWork.GetGenericRepository<Movie>().GetByIdAsync(request.Id);
        if(movie is null)
        {
            return "Movie could not be found!";
        }

        await unitOfWork.GetGenericRepository<Movie>().DeleteAsync(movie);
        await unitOfWork.SaveChangesAsync();

        return "Movie is deleted successfully!";
    }
}