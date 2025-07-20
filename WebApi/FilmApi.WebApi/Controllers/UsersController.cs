using FilmApi.Application.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using FilmApi.Domain.Entities;

namespace FilmApi.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await unitOfWork.GetGenericRepository<Movie>().GetAllAsync());
        }
    }
}
