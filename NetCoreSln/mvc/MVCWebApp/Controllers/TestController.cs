using MVCWebApp.Models;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class TestController : Controller
    {
        MiniProfiler profiler = MiniProfiler.Current;

        // GET: Test
        public ActionResult Index()
        {
            using (profiler.Step("peak Profile Index"))
            {
                if (true)
                {
                    return   View();
                }
                else
                {
                    //return Content("Hi Welcome");
                }
            }
        }

        public string HelloWorld()
        {
            return "Hi, HelloWorld";
        }


        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }

        public ActionResult GetView()
        {
            Employee emp = new Employee();
            emp.FirstName = "Sukesh";
            emp.LastName = "Marla";
            emp.Salary = 20000;

            ViewData["Employee"] = emp;
            return View("MyView");
        }
    }
}