using Microsoft.AspNetCore.Mvc;
using freakSearch.Models;

namespace freakSearch.Controllers;

// routes to /api/ControllerName/RouteName
//ex. /api/Episode/AllEpisodes
[Route("api/[controller]")]
[ApiController]
public class EpisodeController : Controller
{
    private readonly ILogger<EpisodeController> _logger;
    private MyContext _context;

    public EpisodeController(ILogger<EpisodeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("All")]
    public IActionResult GetAllEpisodes()
    {
        var episodes = _context.Episodes.ToList();
        return Ok(episodes);
    }
    // [HttpGet("search?searchInput={query}")]
    [HttpGet("search/{query}")]
    public IActionResult SearchEpisodes(string query)
    {
        Console.WriteLine(query);
        var AllEpisodes = _context.Episodes.ToList();
        var searchEngine = new EpisodeSearchEngine();
        searchEngine.AddEpisodesToIndex(AllEpisodes);
        var episodes = searchEngine.Search(query);

        return Ok(episodes);
    }

    // [HttpPost("episodes/search")]
    // public IActionResult Search(string query)
    // {
    //     return RedirectToAction("SearchEpisodes", new { query = query });
    // }
}