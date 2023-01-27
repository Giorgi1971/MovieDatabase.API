using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.API.Models.Requests;

namespace MovieDatabase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {


        [HttpPost("/movie/add")]
        public async Task<IActionResult> Add([FromBody] MovideAddRequest request)
        {

        }
    }
}
