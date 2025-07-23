using FilmApi.Application.Features.Auth.Command.Login;
using FilmApi.Application.Features.Auth.Command.RefreshToken;
using FilmApi.Application.Features.Auth.Command.Register;
using FilmApi.Application.Features.Auth.Command.Revoke;
using FilmApi.Application.Features.Auth.Command.RevokeAll;
using FilmApi.WebApi.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmApi.WebApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            var response = await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(response.StatusCode, response);
        }
    }
}
