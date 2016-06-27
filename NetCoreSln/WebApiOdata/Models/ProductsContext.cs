using System.Data.Entity;

namespace WebApiOdata.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
                : base("name=ProductsContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<DemoClass> Demos { get; set; }
        
    }
}