using Microsoft.AspNetCore.Mvc;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class PartyController : Controller
    {
        public ActionResult Index()
        {
            return View(Repository.GetGuests());
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Guest guest)
        {
            if (ModelState.IsValid)
            {
                Repository.CreateGuest(guest);
                return RedirectToAction(nameof(RegisterMessage), new { id = guest.Id }); //if validation is successfull, redirect to thanks page
            }
            return View(guest); //if validation fails, stay on the register form
        }

        public ActionResult RegisterMessage(int id)
        {
            var guest = Repository.GetGuests().FirstOrDefault(g => g.Id == id);
            return View(guest);
        }

    }
}

