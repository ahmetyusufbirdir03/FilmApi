using FilmApi.Application.Features.Movies.Queries.GetAllMovies;
using FilmApi.WebApi.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmApi.WebApi.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMediator mediator;

        public MovieController(IMediator mediator) : base(mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var response = await mediator.Send(new GetAllMoviesQueryRequest());
            return Ok(response);
        }
    }
}
