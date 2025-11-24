using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CineClub.Models;

namespace CineClub.Data
{
    public class CineIdentityDbContext : IdentityDbContext
    {
        public CineIdentityDbContext(DbContextOptions<CineIdentityDbContext> options) : base(options) { }
        
    }
}

