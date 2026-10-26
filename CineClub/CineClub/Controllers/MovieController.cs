using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineClub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ViewBag.Genres = 
        new SelectList(
            _context.Genres.ToList(), 
            "Id", "Name");

        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        
        ViewBag.Genres = 
        new SelectList(
            _context.Genres.ToList(), 
            "Id", "Name");


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

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    { 
        var movie = _context.Movies.Find(id);
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("List");
    }

}
