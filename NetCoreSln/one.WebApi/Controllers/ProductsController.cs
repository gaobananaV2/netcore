using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace one.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        dynamic context;

        public IHttpActionResult GetProduct(int id)
        {
            //var product = context.Products.FirstOrDefault((p) => p.Id == id);
            var product="";
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

    public class Product
    {
        public int Id { get; set; } 
    }
}
