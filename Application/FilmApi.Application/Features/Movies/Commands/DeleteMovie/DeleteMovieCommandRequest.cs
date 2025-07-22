using FilmApi.Application.Errors;
using MediatR;

namespace FilmApi.Application.Features.Movies.Commands.DeleteMovie;

public class DeleteMovieCommandRequest : IRequest<ErrorResponse<string>>
{
    public Guid Id { get; set; }  // Silinecek filmin ID'si
}
