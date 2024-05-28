using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekti.Models;

namespace Projekti.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Libra>? Libra { get; set; }
        public DbSet<Autore>? Autore { get; set; }
        public DbSet<Zhanre>? Zhanre { get; set; }
        public DbSet<ShtepiBotuese>? ShtepiBotuese { get; set; }
        public DbSet<BotimeLibrash>? BotimeLibrash { get; set; }
        public DbSet<GjendjeLibrash>? GjendjeLibrash { get; set; }
        public DbSet<Kontakt>? Kontakte { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}