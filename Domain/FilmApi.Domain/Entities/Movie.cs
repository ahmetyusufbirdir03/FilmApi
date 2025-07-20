using FilmApi.Domain.Enums;

namespace FilmApi.Domain.Entities;

public class Movie
{
    public Movie()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Title{ get; set; } = string.Empty;
    public string Description{ get; set; } = string.Empty ;
    public DateTime ReleaseDate { get; set; }
    public string Director { get; set; } = string.Empty;
    public MovieGenreEnum Genre { get; set; }

}
