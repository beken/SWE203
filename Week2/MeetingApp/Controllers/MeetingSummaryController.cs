using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers {
    public class MeetingSummaryController : Controller{
        public IActionResult Index(){
            return View();
        }
    }
}