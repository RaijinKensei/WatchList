using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWatchlist.Api.Models;
using MovieWatchlist.Web.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly MovieDbContext _dbContext;
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
    // Chiamata verso l'api OMDB per ricercare il film dalla barra di ricerca
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

    // Chiamata verso l'api per aggiungere ai preferiti il film ricercato
    [HttpPost]
    public async Task<IActionResult> AddToFavorites([FromForm] MovieResult movie)
    {
        var api = _httpClientFactory.CreateClient();

        var response = await api.PostAsJsonAsync(
            "https://moviewatchlistapi20250714201901-bkcpgeccgggcfzcv.canadacentral-01.azurewebsites.net/api/Favorites",
            movie);

        if (response.StatusCode == HttpStatusCode.Conflict)
        {
            TempData["Msg"] = $"Il film «{movie.Title}» è già nei preferiti!";
        }
        else
        {
            TempData["Msg"] = "Errore durante l’aggiunta.";
        }

        TempData["Msg"] = response.IsSuccessStatusCode
        ? $"«{movie.Title}» aggiunto ai preferiti!"
        : $"Errore durante l’aggiunta: {await response.Content.ReadAsStringAsync()}";

        return RedirectToAction("GetFavorites");
    }

    // Chiamata per recuperare la lista di titoli aggiunti ai preferiti
    [HttpGet]
    public async Task<IActionResult> GetFavorites()
    {

        var api = _httpClientFactory.CreateClient();
        
        //recupera tutta la lista dei preferiti
        var favorites = await api.GetFromJsonAsync<List<MovieResult>>(
            "https://moviewatchlistapi20250714201901-bkcpgeccgggcfzcv.canadacentral-01.azurewebsites.net/api/Favorites"
        );

        // Passa la lista di preferiti alla view
        return View("~/Views/Movies/Favorites.cshtml", favorites);

    }

    // Chiamata per eliminare un film dai preferiti tramite imdbID
    [HttpPost]
    public async Task<IActionResult> RemoveFromFavorites(string imdbId)
    {
        var api = _httpClientFactory.CreateClient();
        var res = await api.DeleteAsync(
            $"https://moviewatchlistapi20250714201901-bkcpgeccgggcfzcv.canadacentral-01.azurewebsites.net/api/Favorites/{imdbId}");

        TempData["Msg"] = res.IsSuccessStatusCode
            ? "Film rimosso dai preferiti!"
            : "Film non trovato nei preferiti!";

        return RedirectToAction(nameof(GetFavorites));
    }





}
