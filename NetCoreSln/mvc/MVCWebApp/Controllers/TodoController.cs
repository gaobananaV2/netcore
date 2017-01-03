using GetOrganized.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetOrganized.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            //return View();

            ViewData.Model = Todo.ThingsToBeDone;

            return View();
        }
    }
}