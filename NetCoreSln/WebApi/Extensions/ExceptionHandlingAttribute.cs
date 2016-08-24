using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApi.Extensions
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        { 
            LogHelper.Error("ExceptionHandlingAttribute InternalServerError:", context.Exception);
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}