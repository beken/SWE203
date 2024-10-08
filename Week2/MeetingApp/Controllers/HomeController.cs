using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers {
    public class HomeController : Controller{
        public IActionResult Index(){
            return View(Models.User.GetUsers());
        }

        /*
        public IActionResult Index(){
            return View();
        }
        */
        
        /*
        public String Index(){
            return "Hello World!";
        }
        */
    }
}