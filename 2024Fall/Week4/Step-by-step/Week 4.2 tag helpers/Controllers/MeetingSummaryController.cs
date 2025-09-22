using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers{
    public class MeetingSummaryController : Controller {

        [Route("/MeetingSummary/Index", Name = "Custom")]
        public IActionResult Index(){
            return View();
        }

        public IActionResult Contact(){
            return View();
        }
    }
}