using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CineClub.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CineClub.Controllers;

public class GenreController:Controller
{
    private readonly CineClubDbContext _context;

    public GenreController(CineClubDbContext context)
    {
        _context = context;
    }

     public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        var genres = _context.Genres.ToList();

        return View(genres);
    }

    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    { 
        var genre = _context.Genres.Find(id);
        _context.Genres.Remove(genre);
        _context.SaveChanges();
        return RedirectToAction("List");
    }
}