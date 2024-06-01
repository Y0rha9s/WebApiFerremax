using Microsoft.EntityFrameworkCore;
using WebApiFerremax.Entities;

namespace WebApiFerremax
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Herramienta> DbHerramienta { get; set; }
        public DbSet<HerramientaManual> DbHerramientaManual { get; set; }
    }
}
