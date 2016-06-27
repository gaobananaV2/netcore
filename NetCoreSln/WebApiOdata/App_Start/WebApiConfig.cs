using System.Web.Http;

using WebApiOdata.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace WebApiOdata
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Product>("Demos");


            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
