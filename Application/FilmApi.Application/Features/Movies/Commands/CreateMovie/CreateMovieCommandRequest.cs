
using FilmApi.Application.Response;
using MediatR;

namespace FilmApi.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandRequest : IRequest<Response<CreateMovieCommandResponse>>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public int Genre { get; set; } // MovieGenreEnum sayısal temsil
}
