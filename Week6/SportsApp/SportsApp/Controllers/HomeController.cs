using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

public class HomeController: Controller {
    public ActionResult Index(){
        return View();
    }
}