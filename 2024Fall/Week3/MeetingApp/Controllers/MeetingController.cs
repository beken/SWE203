using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

public class MeetingController: Controller {
    public ActionResult Index(){
        return View();
    }
    public ActionResult List(){
        return View(Repository.users());
    }

    public ActionResult Details(int id){
        return View(Repository.GetById(id));
    }

    [HttpGet]
    public ActionResult Register(){
        return View();
    }

    [HttpPost]
    public ActionResult Register(UserInfo model){
        Repository.CreateUser(model);
        return View("RegisterThanks", model);
    }

    public ActionResult Contact(){
        return View();
    }

}