using Microsoft.AspNetCore.Mvc;
using CineClub.Filters;

[Route("tickets")]
public class TicketController : Controller
{
    // GET /tickets/select/5
    [HttpGet("select/{movieId:int}")]
    public IActionResult SelectShowtime(int movieId)
    {
        // Pass movieId to view for display/demo
        ViewBag.MovieId = movieId;
        return View();
    }

    // POST /tickets/select/5
    [HttpPost("select/{movieId:int}")]
    public IActionResult SelectShowtimePost(int movieId, int showtimeId)
    {
        // Store selected showtime temporarily
        TempData["SelectedShowtimeId"] = showtimeId;
        TempData["SelectedMovieId"] = movieId;

        return RedirectToAction("SelectSeats");
    }

    // GET /tickets/seats
    [HttpGet("seats")]
    
    public IActionResult SelectSeats()
    {
        return View();
    }

    // POST /tickets/confirm
    [HttpPost("confirm")]

    public IActionResult Confirm(string[] selectedSeats)
    {
        // Fake booking id, simulating a created booking
        int fakeBookingId = Random.Shared.Next(1000, 9999);

        return RedirectToAction("Success", new { id = fakeBookingId });
    }

    // GET /tickets/success/1234
    [HttpGet("success/{id:int}")]
    public IActionResult Success(int id)
    {
        ViewBag.BookingId = id;
        return View();
    }
}
