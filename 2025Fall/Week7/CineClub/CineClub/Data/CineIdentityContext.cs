using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CineClub.Data
{
    public class CineIdentityDbContext : IdentityDbContext
    {
        public CineIdentityDbContext(DbContextOptions<CineIdentityDbContext> options) : base(options) { }

    }
}

