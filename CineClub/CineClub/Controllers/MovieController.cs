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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        _context.Movies.Add(movie);  
        _context.SaveChanges(); 
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        var existingMovie = _context.Movies.Find(movie.Id);
        if (existingMovie != null)
            existingMovie.Title = movie.Title;
        
        //_context.Movies.Update(movie);
        _context.SaveChanges();
        return RedirectToAction("List");
    }
}
