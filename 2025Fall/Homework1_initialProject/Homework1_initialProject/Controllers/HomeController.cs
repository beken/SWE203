using Microsoft.AspNetCore.Mvc;
using Homework1.Models;

namespace Homework1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CourseCode = "SWE 203";
            ViewBag.CourseName = "Web Programming";
            ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy");
            
            return View();
        }
    }
}