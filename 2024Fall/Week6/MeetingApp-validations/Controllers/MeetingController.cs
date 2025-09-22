using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers{
    public class MeetingController : Controller {
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        public IActionResult Register(){
            return View();
        }

        [HttpPost]
         public IActionResult Register(UserInfo model){
            if(ModelState.IsValid){
                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.users.Where(i=> i.WillAttend==true).Count();            
                return View("RegistrationThanks", model);
            } else{
                return View("Register", model);
            }  
        }
        
        public IActionResult List(){
            return View(Repository.users); 
        }

        public IActionResult Details(int id){
            return View(Repository.GetById(id));
        }

        public IActionResult RegistrationThanks(){
            return View();
        }
    }
}

