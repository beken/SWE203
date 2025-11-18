using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CineClub.Data;
using CineClub.Models;

namespace CineClub.Controllers
{
    public class MovieController : Controller
    {
        private readonly CineDbContext _context;

        public MovieController(CineDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index(int? genreId, string movieSearchString, int? year, int page = 1, int pageSize = 5)
        {
            IEnumerable<Movie> movies;

            if (genreId.HasValue)
                movies = _context.Movies.Include(m => m.Genre).Where(m => m.GenreId == genreId).ToList();
            else
                movies = _context.Movies.Include(m => m.Genre).ToList();

            if (!string.IsNullOrEmpty(movieSearchString))
            {
                movies = movies.Where(m => m.Title.Contains(movieSearchString) || m.Genre.Name.Contains(movieSearchString));
            }

            ViewData["MovieSearchString"] = movieSearchString;


            //// filter based on year 
            //to fill dropdown menu
            ViewData["Years"] = _context.Movies
                                .Select(m => m.ReleaseYear)
                                .Distinct()
                                .OrderByDescending(y => y)
                                .ToList();
            //selected year 
            ViewData["Year"] = year;

            //actually filter
            if (year.HasValue)
                movies = movies.Where(m => m.ReleaseYear == year.Value);

            //// filter based on genre
            ViewData["Genres"] = _context.Genres //to fill dropdown menu
                                .OrderBy(g => g.Name)
                                .ToList();
            ViewData["GenreId"] = genreId; //selected genre

            if (genreId.HasValue)
                movies = movies.Where(m => m.GenreId == genreId.Value);


            //// pagination
            var totalNumberOfMovies = movies.Count();
            movies = movies
                    .OrderBy(m => m.Title)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = (int)Math.Ceiling(totalNumberOfMovies / (double)pageSize);

            return View(movies);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        
        [Authorize(Roles = "Admin")] 

        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ReleaseYear,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ReleaseYear,GenreId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
