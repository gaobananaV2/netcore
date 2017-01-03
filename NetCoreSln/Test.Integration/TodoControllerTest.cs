using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetOrganized.Models;
using GetOrganized.Controllers;
using System.Web.Mvc;

namespace Test.Integration
{ 
    [TestClass]
    public class TodoControllerTest
    { 
        [TestMethod]
        public void Should_Display_A_List_Of_Todo_Items()
        {
            // Assert.AreEqual(Todo.ThingsToBeDone, new TodoController());

            var viewResult = (ViewResult)new TodoController().Index();
            Assert.AreEqual(Todo.ThingsToBeDone, viewResult.ViewData.Model);
        }
    }
}
