using Microsoft.EntityFrameworkCore;

namespace Interfas
{
    public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Roles.db");
        }
    }
}
