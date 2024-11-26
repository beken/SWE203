using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsApp.Models;

public class ProductController : Controller{

    private readonly StoreDbContext _context;

    public ProductController(StoreDbContext context){
            _context = context;
    }
    public ActionResult Index(string sortOrder, int? pageNumber){
        ViewData["CurrentSort"] = sortOrder;
        
        ViewData["IdSortParm"] = sortOrder == "id_asc" ? "id_desc" : "id_asc";
        ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
        ViewData["PriceSortParm"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";

        var products = _context.Products
        .Include(p => p.ProductCategory)
        .AsQueryable();   // we want to apply further queries on the products such as order by

        switch (sortOrder)
        {
            case "name_asc":
                products = products.OrderBy(p => p.Name);
                break;
            case "name_desc":
                products = products.OrderByDescending(p => p.Name);
                break;
            case "price_asc":
                products = products.OrderBy(p => p.Price);
                break;
            case "price_desc":
                products = products.OrderByDescending(p => p.Price);
                break;
            case "id_asc":
                products = products.OrderBy(p => p.ProductID);
                break;
            case "id_desc":
                products = products.OrderByDescending(p => p.ProductID);
                break;
            default:
                products = products.OrderBy(p => p.Name);
                break;
        }

        int pageSize = 3;
        var paginatedProducts = PaginatedList<Product>
        .Create(products.ToList(), pageNumber ?? 1, pageSize);
        
        return View(paginatedProducts);
    }

    [HttpGet]
     public ActionResult Create(){
        return View();
    }

    [HttpPost]
     public async Task<ActionResult> Create(Product product){
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

   [HttpGet]
    public async Task<IActionResult> Update(long? productId){
        var product = await _context.Products.FindAsync(productId);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Update(long id, Product product){
        product.ProductID = id;
        try{
            _context.Update(product);
            await _context.SaveChangesAsync();
        }catch(Exception){
            throw;
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long? id){
        var product = await _context.Products.FindAsync(id);
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] long id){
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
}