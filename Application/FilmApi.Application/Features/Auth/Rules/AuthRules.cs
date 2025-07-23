using FilmApi.Application.Bases;
using FilmApi.Application.Features.Auth.Exceptions;
using FilmApi.Domain.Entities;

namespace FilmApi.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null) throw new UserAlreadyExistException();
        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeExist(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
        return Task.CompletedTask; 
    }

    public Task SessionShouldNotBeExpired(DateTime? refreshTokenExpiryDate)
    {
        if (refreshTokenExpiryDate <= DateTime.Now) throw new SessionShouldNotBeExpired();
        return Task.CompletedTask;
    }

    public Task EmailAdressShouldBeValid(User? user)
    {
        if (user is null) throw new EmailAdressShouldBeValidException();
        return Task.CompletedTask;
    }
}
