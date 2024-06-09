using Bnka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bnka.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Members> Members { get; set; }

    }
}
