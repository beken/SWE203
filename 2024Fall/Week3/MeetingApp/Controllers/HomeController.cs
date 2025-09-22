using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;
using Microsoft.VisualBasic;

namespace MeetingApp.Controllers{
    public class HomeController : Controller{

        public ViewResult Index(){
            int dateTime = DateTime.Now.Hour;

            //string name = "Beyza";
            //return View(model: name);

            ViewData["name"] = "Beyza";
            ViewData["hello"] = dateTime < 12 ? "Good morning" : "Good afternoon";
            

            ViewBag.name = "Beyza";
            ViewBag.hello = dateTime < 12 ? "Good morning" : "Good afternoon";
            ViewBag.count = Repository.users().Where(info => info.WillAttend == true).Count();

            return View();

        }
    }
}