using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

public class ProductReviewController : Controller{

    private readonly StoreDbContext _context;

    public ProductReviewController(StoreDbContext context){
            _context = context;
        }
    public ActionResult Index(){
        return View(_context.ProductReviews);
    }

    [HttpGet]
     public ActionResult Create(){
        return View();
    }

    [HttpPost]
     public async Task<ActionResult> Create(ProductReview productReview){
        _context.ProductReviews.Add(productReview);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

 
    [HttpGet]
    public async Task<IActionResult> Delete(long? id){
        var ProductReview = await _context.ProductReviews.FindAsync(id);
        return View(ProductReview);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] long id){
        var ProductReview = await _context.ProductReviews.FindAsync(id);
        _context.ProductReviews.Remove(ProductReview);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
}