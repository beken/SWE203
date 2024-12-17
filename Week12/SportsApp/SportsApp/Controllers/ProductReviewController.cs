using System.Xml.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

public class ProductReviewController : Controller{

    private readonly StoreDbContext _context;

    public ProductReviewController(StoreDbContext context){
            _context = context;
        }

    public ActionResult Index(long id){
        if (User.IsInRole("Admin")){
            return RedirectToAction("AdminIndex"); 
        }

        ViewData["ProductID"] = id;

        var product = _context.Products.Include(p => p.Reviews).FirstOrDefault(p => p.ProductID == id);
        var reviews = product.Reviews;
        return View(reviews);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult AdminIndex(){
        return View(_context.ProductReviews);
    }

    public ActionResult ReviewsByUser(){
        var currentUserName = User.Identity.Name;
        var reviews = 
        _context.ProductReviews.Where(pr => pr.ReviewerName == currentUserName);
        return View("Index", reviews);
    }


    [HttpGet]
     public ActionResult Create(long id){
        var review = new ProductReview { 
            ProductID = id,
            ReviewerName = User.Identity.Name
        };
        return View(review);
    }

    [HttpPost]
     public async Task<ActionResult> Create(ProductReview productReview){
        _context.ProductReviews.Add(productReview);
        await _context.SaveChangesAsync();
      
        return RedirectToAction("Index", 
        new { id = productReview.ProductID }
        );
        //we are passing ProductID as route value (not a model), route becomes smth like /ProductReview/Index?id=1 
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