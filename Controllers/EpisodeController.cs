using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
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

    [HttpGet("search")]
    public IActionResult SearchEpisodes(string query)
    {
        var AllEpisodes = _context.Episodes.ToList();
        var searchEngine = new EpisodeSearchEngine();
        searchEngine.AddEpisodesToIndex(AllEpisodes);
        var episodes = searchEngine.Search(query);
        // var episodes = _context.Episodes
        //     .Where(e => e.Title.Contains(query)
        //                 || e.Summary.Contains(query)
        //                 || e.Link.Contains(query)
        //                 || e.Transcript.Contains(query))
        //     .ToList();

        return Ok(episodes);
    }
}