using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.IdentityModel.Tokens;
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
            if (request.Name.IsNullOrEmpty() || request.Name.Length > 200) throw new Exception("Name validation");
            if (request.Description.IsNullOrEmpty() || request.Description.Length > 2000) throw new Exception("Description validation");
            if (request.Year < 1895) throw new Exception("Year validation");
            if (request.Director.IsNullOrEmpty() || request.Director.Length > 50) throw new Exception("Director validation");

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
            if (request.Name.IsNullOrEmpty() || request.Name.Length > 200) throw new Exception("Name validation");
            if (request.Description.IsNullOrEmpty() || request.Description.Length > 2000) throw new Exception("Description validation");
            if (request.Year < 1895) throw new Exception("Year validation");
            if (request.Director.IsNullOrEmpty() || request.Director.Length > 50) throw new Exception("Director validation");

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
