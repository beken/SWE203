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
            return View("RegistrationMessage", guest);

            /*if (guest.WillAttend)
                return View("RegisterThanks", guest);
            else
                return View("RegisterSorry", guest);
            */
            //return View(); //returns the view with the action name (Register)
        }

    }
}