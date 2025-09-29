using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

public class HomeController : Controller
{
    /*
    public string Index()
    {
        return "Plain text hello app!";
    }*/

    /*public ActionResult Index()
    {
        return View();
    }*/

    public IActionResult Index()
    {
        Message message = new Message();
        return View(message);
    }
    //localhost:portnumber/Home/ItemList
    public ActionResult ItemList()
    {
        List<Item> items = new List<Item>
        {
            new Item {Id = 1, Name = "Book"},
            new Item {Id = 2, Name = "Laptop"}
        };
        return View(items);
    }
}
