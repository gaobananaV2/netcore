using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using WebApiOdata.Models;

namespace WebApiOdata.Controllers
{
    public class DemosController :  ODataController
    {
        ProductsContext db = new ProductsContext();

        [EnableQuery]
        public IQueryable<DemoClass> Get()
        {
            return db.Demos;
        }
    }
}
