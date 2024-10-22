using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers{
    public class HomeController : Controller {

         //localhost..../home/index
        public IActionResult Index(){
            int time = DateTime.Now.Hour;

            //---------------- With Model -----------------
            //var sayHello = time > 12 ? "Good Day" : "Good Morning";            
            //return View(model: sayHello);  

            //---------------- With ViewBag -----------------
            //ViewBag.sayHello = time > 12 ? "Good Day" : "Good Morning";
            //ViewBag.username = "Beyza";
            //ViewBag.dateTime = "system time is: " + time;
            

            //---------------- With ViewData-----------------
            ViewData["hello"] = time > 12 ? "Good Day" : "Good Morning";             
            int usercount = Repository.users.Where(info => info.WillAttend == true).Count();
            ViewBag.NoP = usercount;

            return View();
            
        }
    }
}