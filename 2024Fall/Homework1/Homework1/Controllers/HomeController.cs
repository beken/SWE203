using Microsoft.AspNetCore.Mvc;
using Homework1.Models;

namespace Homework1.Controllers{
    public class HomeController : Controller {
        public IActionResult Index(){
           return View(Repository.Announcements);
        }
    }
}