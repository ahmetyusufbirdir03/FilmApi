using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandRequest : IRequest<Response<string>>
{
    public Guid Id { get; set; }  // Silinecek filmin ID'si
}
