using Microsoft.AspNetCore.Mvc;
using SportsApp.Models;

public class ShippingOrderController:OrderController{
    private readonly StoreDbContext _context;

    public ShippingOrderController(StoreDbContext _context) : base(_context){ }

}