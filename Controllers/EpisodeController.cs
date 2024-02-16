using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using freakSearch.Models;

namespace freakSearch.Controllers;

public class EpisodeController : Controller
{
    private readonly ILogger<EpisodeController> _logger;
    private MyContext _context;

    public EpisodeController(ILogger<EpisodeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("GetAllEpisodes")]
    public IActionResult GetAllEpisodes()
    {
        var episodes = _context.Episodes.ToList();
        // Log the episodes
        _logger.LogInformation("Episodes: {Episodes}", episodes);
        return Ok(episodes);

    }
}