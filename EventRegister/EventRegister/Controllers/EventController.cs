using Microsoft.AspNetCore.Mvc;

public class EventController: Controller
{
    public IActionResult Index()
    {
        var guests = Repository.GetGuests();
        return View(guests);
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Guest guest)
    {
        if(ModelState.IsValid == false)
        {
            return View(guest);
        }
        else
        {
            Repository.CreateGuest(guest);
        //return View(guest);
        return RedirectToAction("Index");
        //return Content($"Thank you {guest.Name} for registering. We will contact you at {guest.Email}.");
        }
    }

    public IActionResult GuestDetails(int id)
    {
        var guest = Repository.GetGuestById(id);
        if(guest == null)
        {
            return NotFound();
        }
        return View("GuestDetails", guest);
    }
}