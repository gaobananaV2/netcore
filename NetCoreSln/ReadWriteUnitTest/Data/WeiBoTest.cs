using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.sqlhelper;

namespace ReadWriteUnitTest.Data
{
    [TestClass]
    public class WeiBoTest
    {
        [TestMethod]
        public void TestWeiBoGetList()
        {
            var result = new WeiBo().GetList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
