using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApi.Tests.ApiTest
{
    [TestClass]
    public class ValuesControllerUnitTest : ApiTestBase
    {
        public override string GetBaseAddress()
        {
            return "http://localhost:58986/";
        }

        [TestMethod]
        public void GetValue()
        {
            var result = InvokeGetRequest<List<string>>("api/Values");  
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
