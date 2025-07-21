using FilmApi.Application.Features.Users.Commands.CreateUser;
using FilmApi.Application.Features.Users.Commands.DeleteUser;
using FilmApi.Application.Features.Users.Commands.UpdateUser;
using FilmApi.Application.Features.Users.Queries.GetAllUsers;
using FilmApi.Application.Features.Users.Queries.GetUserById;
using FilmApi.WebApi.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmApi.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await mediator.Send(new GetUserByIdQueryRequest { Id = id });
            return Ok(response);
        }

    }
}
