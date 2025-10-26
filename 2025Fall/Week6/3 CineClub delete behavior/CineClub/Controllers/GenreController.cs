using CineClub.Data;
using CineClub.Models;
using Microsoft.AspNetCore.Mvc;

public class GenreController : Controller
{
    private CineDbContext _context;

    public GenreController(CineDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost] 
    public IActionResult Create(Genre genre)
    {
        _context.Genres.Add(genre);
        _context.SaveChanges();
        //return View();
        return RedirectToAction("Read");
    }
    public IActionResult Read()
    {
        var genres = _context.Genres.ToList();
        return View(genres);
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var genre = _context.Genres.FirstOrDefault(g => g.Id == id);
        return View(genre);
    }

    [HttpPost]
    public IActionResult Update(Genre updatedGenre)
    {
        var existingGenre = _context.Genres.FirstOrDefault(g => g.Id == updatedGenre.Id);
        existingGenre.Name = updatedGenre.Name;
        _context.SaveChanges();
        return RedirectToAction("Read");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var genre = _context.Genres.FirstOrDefault(g => g.Id == id);
        return View(genre); 
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var genre = _context.Genres.FirstOrDefault(g => g.Id == id);
        _context.Genres.Remove(genre);
        _context.SaveChanges();
        return RedirectToAction("Read");
    }
}