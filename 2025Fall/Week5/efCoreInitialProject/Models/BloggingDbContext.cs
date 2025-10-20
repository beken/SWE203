using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using BloggingApp.Models;

public class BloggingDbContext: DbContext
{
    public BloggingDbContext(DbContextOptions<BloggingDbContext> options) : base(options) { }

    public DbSet<Blog> Blogs => Set<Blog>();

}