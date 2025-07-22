using Bogus;
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
            var faker = new Faker("tr");

            var movieFaker = new Faker<Movie>("tr")
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.Title, f => f.Lorem.Sentence(3))
                .RuleFor(m => m.Description, f => f.Lorem.Paragraph())
                .RuleFor(m => m.ReleaseDate, f => f.Date.Past(10))
                .RuleFor(m => m.Director, f => f.Name.FullName())
                .RuleFor(m => m.Genre, f => f.PickRandom<MovieGenreEnum>());

            List<Movie> fakeMovies = movieFaker.Generate(5);

            builder.HasData(fakeMovies);
        }
    }
}
