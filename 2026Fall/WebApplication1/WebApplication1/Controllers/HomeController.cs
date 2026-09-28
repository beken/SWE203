using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    /* public string Index()
    {
        return "Hello from controller!";
    }  */

    /* public IActionResult Index()
    {
        return View();
    } */

    //You can use ViewResult instead of IActionResult if you are returning a view
    //IActionResult is more general and can return different types of results (view, json, etc.), while ViewResult is specifically for returning views.
    
    public ViewResult Index()
    {   Message message = new Message();
        message.Text = "This is a message from model";
        return View(message);
    }
    public ViewResult ListItems()
    {
        Item item1 = new Item();
        item1.Name = "Laptop";
        item1.Price = 72.99m;
        
        Item item2 = new Item();
        item2.Name = "Mobile phone";
        item2.Price = 45.49m;

        List<Item> items = new List<Item> { item1, item2 };

        return View(items);
    }
}