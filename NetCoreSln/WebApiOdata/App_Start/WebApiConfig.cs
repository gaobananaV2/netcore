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
            builder.EntitySet<DemoClass>("Demos");

            builder.Namespace = "ProductService";
            builder.EntityType<Product>()
                .Action("Rate")
                .Parameter<int>("Rating");
            //POST  /Products(1)/ProductService.Rate

            builder.Namespace = "ProductService";
            builder.EntityType<Product>().Collection
                .Function("MostExpensive")
                .Returns<double>();
            //GET  /Products/ProductService.MostExpensive 

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
