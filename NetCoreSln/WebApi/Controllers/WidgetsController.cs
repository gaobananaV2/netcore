using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/widgets")]
    public class WidgetsController : ApiController
    {
        private static readonly IWidgetRepository widgetRepo = new WidgetRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(widgetRepo.Get(User.IsInRole("Praemium"), User.IsInRole("Microsoft")));
        }

        [Route("praemium")]
        [Authorize(Roles ="praemium,admin")]
        public IHttpActionResult GetPraemium()
        {
            return Ok(widgetRepo.Get(true,false));
        }

        [Route("microsoft")]
        [Authorize(Roles = "microsoft.admin")]
        public IHttpActionResult GetMicrosoft()
        {
            return Ok(widgetRepo.Get(false, true));
        }

        [Route("all")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult GetAll()
        {
            return Ok(widgetRepo.Get(true, true));
        }

    }

}
