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

            ViewBag.Name = guest.Name;
            ViewBag.WillAttend = guest.WillAttend;
            //ViewData["title"] = "RSVP app";

            return View("RegistrationMessage");


            /*if (guest.WillAttend)
                return View("RegisterThanks", guest);
            else
                return View("RegisterSorry", guest);
            */
            //return View(); //returns the view with the action name (Register)
        }

    }
}