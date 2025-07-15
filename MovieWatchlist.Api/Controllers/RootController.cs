using Microsoft.AspNetCore.Mvc;

namespace MovieWatchlist.Api.Controllers
{
    [ApiController]
    [Route("/Home")]
    public class HomeController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API MovieWatchlist Root");
        }


    }
}
