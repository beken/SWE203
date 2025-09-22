using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers{
    public class MeetingController : Controller {
        public ActionResult Index(){
            return View();
        }

        public ActionResult Register(Models.UserInfo model){
            return View();
        }
        public IActionResult List(){
            return View();
        }

        public IActionResult Details(){
            return View();
        }
    }
}