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
                return RedirectToAction("RegisterMessage", new { id = guest.Id });
            }

            return View(guest);
        }

        public ActionResult RegisterMessage(int id)
        {
            var guest = Repository.GetGuests().FirstOrDefault(i => i.Id == id);
            return View(guest);
        }

        public ActionResult GuestDetails(int id)
        {
            var guest = Repository.GetGuests().FirstOrDefault(i => i.Id == id);
            return View(guest);
        }

    }
}