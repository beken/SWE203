using CineClub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineClub.Controllers.Api;

[ApiController]
[Route("api/movies")]
public class MoviesApiController : ControllerBase
{   
    private readonly CineDbContext _context;

    public MoviesApiController(CineDbContext context)
    {
        _context = context;
    }

    [HttpGet] 
    public ActionResult GetAll()
    {
        var movies = 
        _context.Movies
        .Include(m => m.Genre)
        .Select(m => new 
        {
            title = m.Title,
            genreName = m.Genre.Name
        }).ToList();

        if(movies == null)
        {
            return NotFound();
        }

        return Ok(movies); //JSON 
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var movie = 
        _context.Movies.Where(m => m.Id == id);
        
        return Ok(movie); //JSON 
    }
    
    // .. api/movies/search?title=inception
    [HttpGet("search")]
    public ActionResult SearchByTitle(string? title)
    {
        var movies = 
        _context.Movies
        //.Where(m => m.Title.Contains(title));
        .Where(m => EF.Functions.Like(m.Title, $"%{title}%"));
        
        return Ok(movies); //JSON 
    }

}