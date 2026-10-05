using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        //ViewBag.CafeteriaName = "Sakarya University Cafeteria";
        //ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy");

        return View();
    }
}
