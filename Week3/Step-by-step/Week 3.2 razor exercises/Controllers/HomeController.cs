using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers{
    public class HomeController : Controller {
        public IActionResult Index(){
            //return View();
             return View(Repository.users); 
        }
    }
}