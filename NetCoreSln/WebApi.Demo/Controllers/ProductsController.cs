using System.Web.Http;
using WebApi.Demo.Models;

namespace WebApi.Demo.Controllers
{
    public class ProductsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var product = new Product
            {
                Id = "c1",
                Name = "ThinkPad E200",
                Price = 20000,
                Category = "Computer"
            };
            return Ok(product);
        }
 

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

}
