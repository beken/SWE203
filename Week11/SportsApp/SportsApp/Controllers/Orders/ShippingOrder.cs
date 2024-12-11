using Microsoft.AspNetCore.Mvc;
using SportsApp.Models;

public class ShippingOrderController:OrderController{
        private readonly StoreDbContext _context;

        public ShippingOrderController(StoreDbContext _context) : base(_context){}

//[ShippingOrder/ShippingOrderCreate?OrderID=1}

    [HttpPost("ShippingOrder/ShippingOrderCreate/{OrderID}")]
    [HttpGet("ShippingOrder/ShippingOrderCreate/{OrderID}")]
    public IActionResult ShippingOrderCreate(Order order){
        var ShippingOrder = new ShippingOrder();
        ShippingOrder.OrderID = order.OrderID;
        ShippingOrder.products = order.products;

        _context.ShippingOrders.Add(ShippingOrder);
        _context.SaveChanges();

        return View("~/Views/Order/CheckOut");
    }

}