using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineClub.Models;
using SQLitePCL;
using CineClub.Data;

namespace CineClub.Controllers;

public class HomeController : Controller
{
    private CineDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, CineDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var allGenres = _context.Genres.ToList();
        return View(allGenres);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
