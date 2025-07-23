using FilmApi.Application.Features.Movies.Commands.CreateMovie;
using FilmApi.Application.Features.Movies.Commands.DeleteMovie;
using FilmApi.Application.Features.Movies.Commands.UpdateMovie;
using FilmApi.Application.Features.Movies.Queries.GetAllMovies;
using FilmApi.Application.Features.Movies.Queries.GetMovieById;
using FilmApi.WebApi.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetAllMovies()
        {
            var response = await mediator.Send(new GetAllMoviesQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var response = await mediator.Send(new GetMovieByIdQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateMovie(CreateMovieCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteMovie(DeleteMovieCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
