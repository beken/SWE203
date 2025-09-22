using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;
public class HomeController : Controller{

    private readonly StoreDbContext _context;

    public HomeController(StoreDbContext context){
        _context = context;
    }
    public ActionResult Index(){
        var cheapestItem = _context.Products.Include(p => p.Reviews)
        .OrderBy(p => p.Price).FirstOrDefault();
    
        return View(cheapestItem);
    }

    public ActionResult SearchProductByName(string name){
        //SELECT * FROM Products WHERE Name LIKE '%name%' ORDER BY Name
        var products = _context.Products
        .Include(p => p.ProductCategory)
        .Where(p => p.Name.Contains(name)).OrderBy(p => p.Name); 

        return View("~/Views/Product/DetailsList.cshtml", products);      
    }
    
}