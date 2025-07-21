using FilmApi.Domain.Enums;

namespace FilmApi.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandResponse
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public MovieGenreEnum Genre { get; set; }
}
