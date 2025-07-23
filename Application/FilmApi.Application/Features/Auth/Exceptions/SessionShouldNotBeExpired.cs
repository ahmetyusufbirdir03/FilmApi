using FilmApi.Application.Bases;

namespace FilmApi.Application.Features.Auth.Exceptions;

public class SessionShouldNotBeExpired : BaseException
{
    public SessionShouldNotBeExpired() : base("Your session has expired. Please log in again!") { }
}
