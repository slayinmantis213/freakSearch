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

    [HttpGet("AllEpisodes")]
    public IActionResult GetAllEpisodes()
    {
        var episodes = _context.Episodes.ToList();
        return Ok(episodes);
    }

    [HttpGet("AllTitles")]
    public IActionResult GetAllEpisodeNames()
    {
        var episodes = _context.Episodes.Select(e => new { e.Title, e.EpisodeNumber, e.Link }).ToList();
        return Ok(episodes);
    }
}