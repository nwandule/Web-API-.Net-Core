using Demo_App.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Data
{
    //this normal class that must inherit from dbcontext class 
    public class DemoDbContext:DbContext
    {
      //inject bdcontext
        public DemoDbContext(DbContextOptions<DemoDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        //create your databases
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public object Product { get; internal set; }
    }
}
