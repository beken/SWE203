using Microsoft.AspNetCore.Mvc;

namespace RSVPApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}