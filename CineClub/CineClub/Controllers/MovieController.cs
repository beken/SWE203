using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineClub.Models;

namespace CineClub.Controllers;

public class MovieController : Controller
{
    private readonly CineClubDbContext _context;

    public MovieController(CineClubDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }
}
