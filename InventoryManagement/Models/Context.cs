using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { }

        public DbSet<Product> Products { get; set;}
        public DbSet<Dealer> Dealers { get; set;}
     

    }
}
