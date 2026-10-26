using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers;

public class HomeController : Controller
{
    private readonly LibraryContext _context;

    public HomeController(LibraryContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var today = DateTime.Today;

        ViewBag.BookCount = _context.Books.Count();
        ViewBag.AuthorCount = _context.Authors.Count();
        ViewBag.ActiveCount = _context.Borrowings.Count(br => br.ReturnDate == null);

        var overdue = _context.Borrowings
            .Include(br => br.Book)
            .Where(br => br.DueDate < today)
            .OrderBy(br => br.DueDate)
            .ToList();
        ViewBag.Overdue = overdue;

        ViewBag.TopBooks = _context.Books
            .Include(b => b.Borrowings)
            .OrderBy(b => b.Borrowings.Count)
            .Take(5)
            .ToList();

        return View();
    }
}