using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;


namespace MovieWatchlist.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class SearchController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SearchController(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
        {

            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;

        }
        //chiamata verso l'api OMDB per ricercare i film tramite la key di registrazione
        [HttpGet]
        public async Task<IActionResult> Get(string title)
        {

            var apiKey = _configuration["omdb:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
                return BadRequest("OMDb Api Key non configurata.");

            var url = $"https://www.omdbapi.com/?t={title}&apikey={apiKey}";
            var response = await _httpClient.GetAsync(url);

            if(!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode,"Errore nella richiesta.");

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");


        }


    }
}
