using Microsoft.AspNetCore.Mvc;

namespace MovieWatchlist.Api.Controllers
{
    [ApiController]
    [Route("api")] // oppure [Route("api/root")]
    public class ApiRootController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API MovieWatchlist Root");
        }
    }
}