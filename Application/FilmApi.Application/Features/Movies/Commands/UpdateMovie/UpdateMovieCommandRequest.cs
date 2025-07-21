using MediatR;

namespace FilmApi.Application.Features.Movies.Commands.UpdateMovie;

public class UpdateMovieCommandRequest : IRequest<string>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public int Genre { get; set; }  
}
