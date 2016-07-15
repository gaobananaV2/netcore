using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace aspnetcoreWebApp
{
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
