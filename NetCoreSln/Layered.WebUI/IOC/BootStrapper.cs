using Layered.Domains;
using Layered.Repository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Layered.WebUI.IOC
{
    public static class BootStrapper
    {
        public static Container Container = null;
        public static void ConfigureStructureMap()
        {
            Container = new Container(c => { c.AddRegistry<ProductRegistry>(); }); 
        }
    }

    public class ProductRegistry : Registry
    {
        public ProductRegistry()
        {
            For<IProductRepository>().Use<ProductRepository>();
        }
    }
}