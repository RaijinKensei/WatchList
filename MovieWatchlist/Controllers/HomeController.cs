using Microsoft.AspNetCore.Mvc;
using MovieWatchlist.Web.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Search(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            return RedirectToAction("Index");
        }

        var client = _httpClientFactory.CreateClient("MovieAPI");
        var response = await client.GetAsync($"/api/search?title={title}");

        if (!response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        var content = await response.Content.ReadAsStringAsync();
        var movie = JsonSerializer.Deserialize<MovieResult>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View("~/Views/Movies/Result.cshtml", movie);
    }
}
