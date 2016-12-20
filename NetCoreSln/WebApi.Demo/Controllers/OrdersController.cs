using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Demo.Models;

namespace WebApi.Demo.Controllers
{
    public class OrdersController : ApiController
    {
        [Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<Order> FindOrdersByCustomer(int customerId)
        {
            return null;
        }
    }
}
