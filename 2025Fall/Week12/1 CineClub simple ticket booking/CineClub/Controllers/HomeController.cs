using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using CineClub.Models;
using CineClub.Data;

namespace CineClub.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CineDbContext _context;

    private readonly IHubContext<ReviewsHub> _hub;

    public HomeController(ILogger<HomeController> logger, CineDbContext context, IHubContext<ReviewsHub> hub)
    {
        _logger = logger;
        _context = context;
        _hub = hub;
    }

    public IActionResult Index()
    {
        var allGenres = _context.Genres.ToList();
        return View(allGenres);
    }

    public IActionResult About()
    {
        throw new Exception("demo exception");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Chat()
    {
        return View();
    }
}
