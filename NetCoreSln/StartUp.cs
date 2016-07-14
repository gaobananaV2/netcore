using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Text;
namespace ConsoleApp
{
    //The Startup class is where the you define the request handling pipeline 
    //and where any services 
    //needed by the app are configured.
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(context =>
            {
                UTF8Encoding uniencoding = new UTF8Encoding();
                byte[] result = uniencoding.GetBytes("Hello from ASP.NET Core!");
                context.Response.ContentType = "text/html";
                return context.Response.Body.WriteAsync(result, 0, result.Length);
            });
        }
    }
}
