using Microsoft.AspNetCore.Mvc;
using freakSearch.Models;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("hosts")]
    public async Task<IActionResult> GetAllPresenters()
    {
        var presentersWithEpisodes = await _context.Presenters
            .Select(p => new
            {
                Presenter = p,
                Episodes = _context.PresentedBys
                    .Where(pb => pb.PresenterId == p.Id)
                    .Select(pb => pb.Episode)
                    .ToList()
            })
            .ToListAsync();

        return Ok(presentersWithEpisodes);
    }

    [HttpGet("guests")]
    public async Task<IActionResult> GetAllGuests()
    {
        var guestsWithEpisodes = await _context.Guests
            .Select(g => new
            {
                Guest = g,
                Episodes = _context.GuestsofEpisodes
                    .Where(pb => pb.GuestId == g.Id)
                    .Select(pb => pb.Episode)
                    .ToList()
            })
            .ToListAsync();

        return Ok(guestsWithEpisodes);
    }
}