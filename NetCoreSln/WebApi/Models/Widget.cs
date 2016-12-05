using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Widget
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int InventedYear { get; set; }

        public bool IsMicrosoftSecured { get; set; }

        public bool IsSecured { get; set; }

        public bool IsPramiumSecured { get; set; }
    }
}