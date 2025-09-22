using Microsoft.AspNetCore.Mvc;
using SportsApp.Models;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
public class OrderController : Controller{
    private readonly StoreDbContext _context;

    public OrderController(StoreDbContext context){
        _context = context;
    }

    //private static List<Product> basket = new List<Product>();

    [HttpPost]
    public IActionResult AddToBasket(long id){
        var product = _context.Products.Find(id);

        //get basket content from session, create a new one if it doesn't exist
        var jsonStringBasket = HttpContext.Session.GetString("basket");
        var basket = string.IsNullOrEmpty(jsonStringBasket)
                        ? new List<Product>()
                        : JsonConvert.DeserializeObject<List<Product>>(jsonStringBasket);

        basket.Add(product);
        
        //add the content of basket (list of products) to session & convert the list products into json string
        HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basket));
      
        return RedirectToAction("Basket", basket);
    }

    [HttpGet]
    public IActionResult Basket(){
        //get the content of basket (list of products) from session
        var JsonStringBasket = HttpContext.Session.GetString("basket");
        
        //convert the json string to list 
        //var basket = JsonConvert.DeserializeObject<List<Product>>(JsonStringBasket);
        var basket = string.IsNullOrEmpty(JsonStringBasket) 
                            ? new List<Product>() 
                            : JsonConvert.DeserializeObject<List<Product>>(JsonStringBasket);
            

        return View("Basket", basket);
    }
    
    public IActionResult CheckOut(){
        //get products in basket
        var JsonStringBasket = HttpContext.Session.GetString("basket");
        var basket = JsonConvert.DeserializeObject<List<Product>>(JsonStringBasket); //basket keeps all products 

        //since we are creating a new entity (ShippingOrder) that contains a relationship with an existing entity (Product(s) in basket)
        //1. we need to obtain a tracked instance of the Product(s) that already exist in the database
        //2. then we create a new ShippingOrder entity and link the existing product entities to the ShippingOrder entity
        //3. finally we save the ShippingOrder entity
        //this way, EF Core knows that the products in basket already exist in the db and EF will not create new instances of products in the basket
        //https://learn.microsoft.com/en-us/ef/core/change-tracking/#entity-states
        var foundProducts = basket.Select(p => _context.Products.Find(p.ProductID)).ToList();

        //put tutorials into subscription order, while the rest of the producst will be shipping order.
        int tutorialServiceCategoryId = 6;

        var subscriptionProducts = foundProducts.Where(p => p.ProductCategoryID == tutorialServiceCategoryId).ToList();
        var shippingProducts = foundProducts.Where(p => p.ProductCategoryID != tutorialServiceCategoryId).ToList();

        if(subscriptionProducts.Any()){
            var order = new SubscriptionOrder {
                products = subscriptionProducts,
                RenewalDate = DateTime.Now.AddMonths(1).ToString(),
                RenewalPeriod = "Monthly"
            };
            _context.SubscriptionOrders.Add(order);
        }

        if(shippingProducts.Any()){
            var order = new ShippingOrder {
                products = shippingProducts,
                ShippingAddress = "Default Address",
                ShippingFirm = "Default Firm"
            };
            _context.ShippingOrders.Add(order);
        }
        
        _context.SaveChanges();
     
        return View(foundProducts);
        
    }
}