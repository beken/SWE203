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

            return View("RegisterMessage", guest);

            /*
            if (guest.WillAttend)
                return View("RegisterThanks", guest); // returns RegisterThanks.cshtml
            else
                return View("RegisterSorry", guest); // returns RegisterSorry.cshtml
            */

            //return View(); // returns Register.cshtml
        }

    }
}