using FilmApi.Application.Bases;

namespace FilmApi.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("This user is already exist!") { }
    }
}
