using FilmApi.Application.Bases;

namespace FilmApi.Application.Features.Auth.Exceptions;

public class EmailAdressShouldBeValidException : BaseException
{
    public EmailAdressShouldBeValidException() : base("This email does not exist!") { }
}
