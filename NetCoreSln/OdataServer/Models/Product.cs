using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOdata.Models
{
    //  Use any data-access layer that can translate database entities into models.
    //  /Products(5)
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public string N { get; set; }
    }
}