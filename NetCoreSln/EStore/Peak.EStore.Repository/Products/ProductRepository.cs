using Peak.EStore.Domains.Products;
using System.Collections.Generic;

namespace Peak.EStore.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products = new List<Product>(); 
            return products;
        }
    } 
}
