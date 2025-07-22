using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmApi.Application.Features.Movies.Commands.CreateMovie;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommandRequest>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithName("Başlık");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Açıklama");
        RuleFor(x => x.Director)
            .NotEmpty()
            .WithName("Yönetmen");
        RuleFor(x => x.Genre)
            .NotEmpty();
    }
}
