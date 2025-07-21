using MediatR;

namespace FilmApi.Application.Features.Users.Queries.GetAllUsers;


public class GetAllUsersQueryRequest : IRequest<IList<GetAllUsersQueryResponse>>
{

}
