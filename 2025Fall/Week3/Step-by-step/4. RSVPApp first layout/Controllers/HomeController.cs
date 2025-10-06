using Microsoft.AspNetCore.Mvc;
using RSVPApp.Models;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime partyDate = new DateTime(2025, 10, 15);
            //DateTime partyDate = new DateTime(2025, 10, 4);
            //DateTime partyDate = new DateTime(2025, 10, 6);
            int daysLeft = (partyDate - DateTime.Now).Days;

            ViewBag.PartyDate = partyDate.ToLongDateString();
            ViewBag.DaysLeft = daysLeft;

            ViewData["PartyDate"] = partyDate.ToLongDateString();
            ViewData["DaysLeft"] = daysLeft;


            var whatToBring = new List<string>
            {
                "snacks", "drinks", "board games", "good vibes"
                
            };
            ViewData["WhatToBring"] = whatToBring;


            ViewBag.NumberOfInvitationsSent = Repository.GetGuests().Count();
            ViewBag.NumberOfAccepts = Repository.GetGuests().Where(g => g.WillAttend == true).Count();
            ViewData["NumberOfRejects"] = Repository.GetGuests().Where(g => g.WillAttend == false).Count();

            return View();
        }

    }
}