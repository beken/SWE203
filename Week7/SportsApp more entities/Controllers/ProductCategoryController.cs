using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

public class ProductCategoryController : Controller{

    private readonly StoreDbContext _context;

    public ProductCategoryController(StoreDbContext context){
            _context = context;
        }
    public ActionResult Index(){
        return View(_context.ProductCategories);
    }

    [HttpGet]
     public ActionResult Create(){
        return View();
    }

    [HttpPost]
     public async Task<ActionResult> Create(ProductCategory productCategory){
        _context.ProductCategories.Add(productCategory);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

   [HttpGet]
    public async Task<IActionResult> Update(long? productCategoryId){
        var category = await _context.ProductCategories.FindAsync(productCategoryId);
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, Product productCategory){
        productCategory.ProductID = id;
        try{
            _context.Update(productCategory);
            await _context.SaveChangesAsync();
        }catch(Exception){
            throw;
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long? id){
        var product = await _context.ProductCategories.FindAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] long id){
        var productCategory = await _context.ProductCategories.FindAsync(id);
        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public ActionResult GetProductsInCategory(long id){
        var products = _context.Products.Where(p => p.ProductCategoryID == id);


        return View("~/Views/Product/Index.cshtml", products);
    }
    
}