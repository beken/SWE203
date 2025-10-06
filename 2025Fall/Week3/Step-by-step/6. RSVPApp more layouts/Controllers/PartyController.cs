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
            Repository.CreateGuest(guest);

            //instead of sending Guest object, just send the name and willattend info via view bag and view data

            ViewBag.Name = guest.Name;
            ViewBag.WillAttend = guest.WillAttend;

            return View("RegisterMessage");

            //return View("RegisterMessage", guest);
        }

    }
}