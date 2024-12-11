using Microsoft.AspNetCore.Mvc;
using SportsApp.Models;
using Newtonsoft.Json;
using AspNetCoreGeneratedDocument;
using System.ComponentModel.Design;

public class OrderController : Controller{
    private readonly StoreDbContext _context;

    public OrderController(StoreDbContext context){
        _context = context;
    }

     private static List<Product> basket = new List<Product>();

    [HttpGet]   
    [HttpPost]
    public IActionResult AddToBasket(long id){
        var product = _context.Products.Find(id);
        basket.Add(product);
        HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basket));
        //return View("Basket", basket);
        return RedirectToAction("Basket", basket);
    }

    [HttpGet]
    public IActionResult Basket(){
        var JsonStringBasket = HttpContext.Session.GetString("basket");
        //var basket = JsonConvert.DeserializeObject<List<Product>>(JsonStringBasket);
        var basket = string.IsNullOrEmpty(JsonStringBasket) 
                            ? new List<Product>() 
                            : JsonConvert.DeserializeObject<List<Product>>(JsonStringBasket);
            

        return View("Basket", basket);
    }
//ShippingOrder/ShippingOrderCreate/1?products=SportsApp.Models.Product
    public IActionResult CheckOut(){
        var JsonStringBasket = HttpContext.Session.GetString("basket");
        var basket = JsonConvert.DeserializeObject<List<Product>>(JsonStringBasket);

        var order = new ShippingOrder();
        order.products = basket;
        //order.OrderID=1;

        _context.ShippingOrders.Add(order);
        _context.SaveChanges();

        return View();
        //return RedirectToAction("ShippingOrderCreate", "ShippingOrder", order);
        //return RedirectToAction("SubsriptionOrder", "OrderCreate", order);
    }

}