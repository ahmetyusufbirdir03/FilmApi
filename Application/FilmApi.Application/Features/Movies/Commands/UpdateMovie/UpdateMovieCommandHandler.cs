using AutoMapper;
using FilmApi.Application.Interfaces.UnitOfWork;
using FilmApi.Domain.Entities;
using MediatR;

namespace FilmApi.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommandRequest, string>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<string> Handle(UpdateMovieCommandRequest request, CancellationToken cancellationToken)
    {
        var movie = await unitOfWork.GetGenericRepository<Movie>().GetByIdAsync(request.Id);

        if (movie == null)
            return "Movie could not be found!";

        mapper.Map(request, movie);

        await unitOfWork.GetGenericRepository<Movie>().UpdateAsync(movie);
        await unitOfWork.SaveChangesAsync();
        return "Movie is updated successfully!";
    }
}