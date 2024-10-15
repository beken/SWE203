using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

public class MeetingController: Controller {
    public ActionResult Index(){
        return View();
    }
    public ActionResult List(){
        return View(Repository.users());
    }
}