using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineClub.Models;
using CineClub.Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;

namespace CineClub.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CineDbContext _context;

    public HomeController(ILogger<HomeController> logger, CineDbContext cineDbContext)
    {
        _logger = logger;
        _context = cineDbContext;
    }

    public IActionResult Index()
    {
        return View();
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
