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
        //List all movies in console (only title)
        var movies = _context.Movies.ToList();
        foreach (var m in movies)
        {
            Console.WriteLine($"{m.Title}");
        }

        //List also the genre of the movie, not only the title

        // Option 1: manual query (non EF method)
        var query = from m in _context.Movies
                    join g in _context.Genres on m.GenreId equals g.Id
                    select new { MovieTitle = m.Title, GenreName = g.Name };


        Console.WriteLine("---- using JOIN ----");
        foreach (var item in query)
        {
            Console.WriteLine($"{item.MovieTitle} — {item.GenreName}");
        }
        ////////////////

        //Option 2: add navigation property in model
        // 2.1 Explicit loading
        // 2.2 Eager loading

        //Explicit loading: we are telling which item to load explicitly using the Load() function
        Console.WriteLine("---- using Explicit Loading ----");
        foreach (var m in movies)
        {
            _context.Entry(m).Reference(x => x.Genre).Load();
            Console.WriteLine($"{m.Title} - {m.Genre?.Name}");
        }

        //Explicit loading: we are telling EF to load related data upfront with Include()
        Console.WriteLine("---- using Eager Loading ----");
        var moviesWithGenres = _context.Movies.Include(m => m.Genre).ToList();
        foreach (var m in moviesWithGenres)
        {
            Console.WriteLine($"{m.Title} - {m.Genre?.Name}");
        }


        /// List all genres, all movies, and all reviews
        var genres = _context.Genres
        .Include(g => g.Movies)
        .ThenInclude(m => m.Reviews)
        .ToList();

        Console.WriteLine("---- Genres + Movies + Reviews ----");
        foreach (var g in genres)
        {
            Console.WriteLine($"Genre: {g.Name}");
            foreach (var m in g.Movies)
            {
                Console.WriteLine($"  Movie: {m.Title} ({m.Reviews.Count} review(s))");
                foreach (var r in m.Reviews)
                    Console.WriteLine($"    - {r.Content}");
            }
        }
        ////////////////////////////

        

        /// Cascade delete
        var movie = _context.Movies.Include(m => m.Reviews).FirstOrDefault(m => m.Id == 3);
        var allReviewsCount = _context.Reviews.Count();
        Console.WriteLine($"All review counts before deleting the movie: {allReviewsCount} ");
        
        if(movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        var remainingReviewsCount = _context.Reviews.Count();
        Console.WriteLine($"Review counts after delete: {remainingReviewsCount}");
        ////////////////////////////



        /// Restricted delete
        var genreIdToDelete = 1;
        var genreToDelete = _context.Genres
                            .Include(g => g.Movies) // eager load to check for related movies
                            .FirstOrDefault(g => g.Id == genreIdToDelete);

        try
        {
            _context.Genres.Remove(genreToDelete);
            _context.SaveChanges();
            Console.WriteLine("Genre is deleted!"); // we dont expect this to be run
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n Deletion failed"); // we expect this
            Console.WriteLine("To delete the Genre, you must first delete or reassign all associated Movies.");
        }
        ////////////////////////////


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
