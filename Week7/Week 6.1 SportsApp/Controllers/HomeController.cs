using Microsoft.AspNetCore.Mvc;
using SportsApp.Models;
public class HomeController : Controller{

    private readonly StoreDbContext _context;

    public HomeController(StoreDbContext context){
        _context = context;
    }
    public ActionResult Index(){
        //var firstItem = _context.Products.FirstOrDefault(); 
        
        var min = _context.Products.Min(p => p.Price);
        var cheapestItem = _context.Products.First(p => p.Price == min);

        return View(cheapestItem);
    }
}