using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime partyDate = new DateTime(2025, 10, 15);
            int daysLeft = (partyDate - DateTime.Now).Days;

            ViewBag.partyDate = partyDate.ToLongDateString();
            ViewBag.daysLeft = daysLeft;

            var whatToBring = new List<string>
            {
                "snaks", "drinks", "board games", "good vibes"    
            };
            ViewData["whatToBring"] = whatToBring;

            ViewBag.NumberOfAccepts =
            Repository.GetGuests().
            Where(g => g.WillAttend == true).Count();

            
            // Address information
            /*ViewBag.AddressName = "Sarah’s Apartment";
            ViewBag.AddressStreet = "123 Sunset Boulevard";
            ViewBag.AddressCity = "Istanbul";
            ViewBag.AddressCountry = "Turkey";
            */

            return View();
        }

    }
}