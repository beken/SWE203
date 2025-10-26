using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using BloggingApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BloggingDbContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Welcome to our blogging app!");


//GET all blogs
app.MapGet("/blogs", (BloggingDbContext db) =>
{
    var blogs = db.Blogs.Include(b => b.Posts).ToList();
    return Results.Ok(blogs);
});

// POST a blog data
app.MapPost("/blogs", (Blog blog, BloggingDbContext db) =>
{
    db.Blogs.Add(blog);
    db.SaveChanges();
    //return Results.Created($"/blogs/{blog.BlogId}", blog);
});

//GET a single blog (by id)
app.MapGet("/blogs/{id}", (int id, BloggingDbContext db) =>
{
    var blog = db.Blogs.Include(b => b.Posts).FirstOrDefault(b => b.BlogId == id);
    return blog is null ? Results.NotFound() : Results.Ok(blog);
});

// PUT - update blog by id
app.MapPut("/blogs/{id}", (int id, Blog updated, BloggingDbContext db) =>
{
    if (id != updated.BlogId) return Results.BadRequest();

    db.Entry(updated).State = EntityState.Modified;
    db.SaveChanges();
    return Results.NoContent();
});

// DELETE a blog by id
app.MapDelete("/blogs/{id}", (int id, BloggingDbContext db) =>
{
    var blog = db.Blogs.Find(id);
    if (blog is null) return Results.NotFound();

    db.Blogs.Remove(blog);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();
