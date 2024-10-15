using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers{
    public class HomeController : Controller{
        /*public String Index(){
            return "Hello asdsadasd";
        }*/
    public ViewResult Index(){
        return View();
        
    }

    }
}