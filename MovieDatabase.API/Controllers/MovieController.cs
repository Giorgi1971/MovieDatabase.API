using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Abstractions;
using MovieDatabase.API.Models.Requests;
using MovieDatabase.API.Repositories;

namespace MovieDatabase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository repo)
        {
            _movieRepository = repo;
        }

        [HttpPost("/movie/add")]
        public async Task<IActionResult> Add([FromBody] AddMovieRequest request)
        {
            await _movieRepository.AddMovieAsync(request);
            await _movieRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/movie/get")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null) return NotFound("Movie not found");
            return Ok(movie);
        }
        [HttpPost("/movie/update")]
        public async Task<IActionResult> Update([FromBody] UpdateMovieRequest request)
        {
            var update = await _movieRepository.UpdateMovieAsync(request);
            if (update == null) return BadRequest();

            await _movieRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/movie/delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteMovieRequest request)
        {
            _movieRepository.DeleteMovie(request);
            await _movieRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("/movie/search")]
        public async Task<IActionResult> Search([FromBody] SearchMovieRequest request)
        {
            var movie = _movieRepository.SearchMovie(request);
            if (movie == null) return NotFound("Movie not found !");
            return Ok(movie);
            
        }
    }
}
