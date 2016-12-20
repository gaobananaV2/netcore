using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Tests.Utility;

namespace WebApi.Tests.ControllerTest
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
