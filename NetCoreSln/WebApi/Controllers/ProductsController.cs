using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            Product product = _repository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

    internal class _repository
    {
        internal static Product Get(int id)
        {
            return new Product
            {
                Id = id.ToString(),
                Name = "ThinkPad E200",
                Price = 20000,
                Category = "Computer"
            };
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
