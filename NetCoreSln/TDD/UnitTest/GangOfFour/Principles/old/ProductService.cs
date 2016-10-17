using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MockAndInject.GangOfFour.Principles.old
{
    public class ProductService
    {
        private ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products;
            string storageKey = string.Format("products_in_category_id_{ 0}", categoryId);
            products = (List<Product>)HttpContext.Current.Cache.Get(storageKey);
            if (products == null)
            {
                products = _productRepository.GetAllProductsIn(categoryId);
                HttpContext.Current.Cache.Insert(storageKey, products);
            }

            return products;
        }
    }
     
    //1. ProductService depends on the  ProductRepository class. If the  ProductRepository
    //class changes its API, changes are going to need to be made in the ProductService class.
    //The code is untestable.Without having a real
    
    //2. ProductRepository class connecting to a real
    //database, you’re unable to test the ProductService ’s method because of the tight coupling
    //that exists between these two classes.
    
    //3.Another problem related to testing is the dependency
    //on the HTTP context for use in the caching of the products.It is hard to test code that is so
    //tightly coupled to HTTP context.
    //You’re stuck with the HTTP context for caching.In its current state, using a different cache    
    // storage provider such as Velocity or Memcached would require altering of the  ProductService
    //class and any other class that uses caching.Velocity and Memcached are both distributed mem-
    //ory object caching systems that can be used in place of ASP.NET’s default caching mechanism.
}
