using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers;

public class AuthorsController : Controller
{
    private readonly LibraryContext _context;

    public AuthorsController(LibraryContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var authors = _context.Authors
            .OrderBy(a => a.FullName)
            .ToList();
        return View(authors);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Author author)
    {
        if (!ModelState.IsValid) return View(author);

        _context.Authors.Add(author);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var author = _context.Authors.Find(id);
        if (author == null) return NotFound();
        return View(author);
    }

    [HttpPost]
    public IActionResult Edit(Author author)
    {
        if (!ModelState.IsValid) return View(author);

        _context.Authors.Update(author);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]

public IActionResult Delete(int id)
{
        var author = _context.Authors.Find(id);
        if (author == null) return NotFound();

        _context.Authors.Remove(author);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}