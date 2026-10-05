using Microsoft.AspNetCore.Mvc;

public class HomeController: Controller
{
    public IActionResult Index()
    {
        DateTime eventDate = new DateTime(2026, 10, 15);
        int daysLeft = (eventDate - DateTime.Now).Days;

        //ViewBag.DaysLeft = daysLeft;
        ViewData["DaysLeft"] = daysLeft;

        var guests = Repository.GetGuests();
        ViewData["AttendingGuestsCount"] = guests.Where(g => g.WillAttend == true).ToList().Count;
        return View();
    }
}