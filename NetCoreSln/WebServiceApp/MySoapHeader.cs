using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebServiceApp
{
    public class MySoapHeader:SoapHeader
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

    }
}