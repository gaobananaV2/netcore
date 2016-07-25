using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        { 
            if (true)
            {
                return Content("Hi Welcome"); //return View();
            }
            else
            {
                //return Content("Hi Welcome");
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