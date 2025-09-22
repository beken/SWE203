 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;
public class AnalyticsController : Controller{

    private readonly StoreDbContext _context;

    public AnalyticsController(StoreDbContext context){
        _context = context;
    }
    
    public ActionResult GroupProductsByPrice()
    {
        var products = _context.Products
                                        .AsEnumerable() 
                                        .GroupBy(product => 
                                            product.Price < 50 ? "Under $50" :
                                            product.Price <= 100 ? "$50 - $100" :
                                            product.Price <= 200 ? "$101 - $200" : "Above $200")
                                        .Select(group => new ProductPriceGroup
                                        {
                                            PriceRange = group.Key,
                                            ProductCount = group.Count()
                                        })
                                        .ToList();

    return View("Index", products);
    }
}