using FilmApi.Application.Bases;

namespace FilmApi.Application.Features.Auth.Exceptions;

public class EmailOrPasswordShouldNotBeInvalidException : BaseException
{
    public EmailOrPasswordShouldNotBeInvalidException() : base("Email or password is wrong!") { }
}
