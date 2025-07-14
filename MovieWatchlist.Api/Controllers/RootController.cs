using Microsoft.AspNetCore.Mvc;

namespace MovieWatchlist.Api.Controllers
{
    [ApiController]
    [Route("/")]  // route root
    public class HomeController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API MovieWatchlist On");
        }


    }
}
