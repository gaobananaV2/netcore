using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Dapper;

namespace ReadWriteUnitTest.Data
{
    [TestClass]
    public class WeiBoDapperTestGetList
    {
        [TestMethod]
        public void WeiBoDapper_GetList()
        {
            var result = new WeiBoDapper().GetList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

        }
    }
}
