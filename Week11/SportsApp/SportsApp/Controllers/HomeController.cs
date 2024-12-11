using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

public class HomeController : Controller{

    private readonly StoreDbContext _context;

    public HomeController(StoreDbContext context){
        _context = context;
    }
    public ActionResult Index(){
        // Cheapest product will be listed on the main page
        //var min = _context.Products.Min(p => p.Price);
        //var cheapestProduct = _context.Products.First(p => p.Price == min);

        //Cheapest product and its reviews will be listed on the main page -- eager loading
        //var cheapestProduct = _context.Products.Include(p => p.Reviews).OrderBy(p => p.Price).FirstOrDefault();
        
         //Cheapest product and its reviews will be listed on the main page -- explicit loading
        var cheapestProduct = _context.Products.OrderBy(p => p.Price).FirstOrDefault();
        _context.Entry(cheapestProduct).Collection(p => p.Reviews).Load();

        return View(cheapestProduct);
    }

       
    [HttpGet]       
    public ActionResult SearchByProductName(){
        return View();      
    }

    [HttpPost]
    public ActionResult SearchByProductName(string name){
        //SELECT * FROM Products WHERE Name LIKE '%name%' ORDER BY Name
        var products = _context.Products.Include(p => p.ProductCategory).Where(p => p.Name.ToLower().Contains(name.ToLower())).OrderBy(p => p.Name); 

        return View("~/Views/Product/DetailsList.cshtml", products);      
    }
}