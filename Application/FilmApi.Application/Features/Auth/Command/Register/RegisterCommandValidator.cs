using FluentValidation;

namespace FilmApi.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(2)
            .WithName("İsim");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(2)
            .WithName("Soyisim");

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(50)
            .EmailAddress()
            .MinimumLength(8)
            .WithName("E-posta Adresi");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithName("Parola");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(6)
            .Equal(x => x.Password)
            .WithName("Parola Tekrar");
    }
}