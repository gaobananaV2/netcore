using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        MiniProfiler profiler = MiniProfiler.Current;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            using (profiler.Step("peak Profile About"))
            {
                ViewBag.Message = "Your application description page.";
            }
            return View();
        }

        public ActionResult Contact()
        {
            using (profiler.Step("peak Profile Contact"))
            {
                ViewBag.Message = "Your contact page.";
            }
            return View();
        }
    }
}