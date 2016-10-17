using Layered.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IList<Product> FindAll()
        {

            return new List<Product>() {
                new Product { Id=1,Name="name1",Price=new Price(1, 2)},
                new Product {Id=2,Name="name2",Price=new Price(2, 5) }
            };
            //var products = from p in new ShopDataContext().Products
            //               select new Product
            //               {
            //                   Id = p.ProductId,
            //                   Name = p.ProductName,
            //                   Price = new Price(p.RRP, p.SellingPrice)
            //               };
            //return products.ToList();
        }
    }
}
