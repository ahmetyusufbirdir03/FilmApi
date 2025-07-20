using FilmApi.Domain.Entities;
using FilmApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            Movie movie = new()
            {
                Id = Guid.NewGuid(),
                Title = "TEST",
                Description = "Açıklama",
                ReleaseDate = DateTime.Now,
                Director = "AHMET YUSUF BIRDIR",
                Genre = MovieGenreEnum.Western,
            };
            Movie movie2 = new()
            {
                Id = Guid.NewGuid(),
                Title = "TEST2",
                Description = "Açıklama2",
                ReleaseDate = DateTime.Now.AddDays(1),
                Director = "AHMET YUSUF BIRDIR2222",
                Genre = MovieGenreEnum.Action,
            };
            builder.HasData(movie, movie2);
        }
    }
}
