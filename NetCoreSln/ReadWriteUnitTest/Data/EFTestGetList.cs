using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.EF;
using ReadWriteUnitTest.Data.eftest;

namespace ReadWriteUnitTest.Data
{
    [TestClass]
    public class EFTestGetList
    {
        [TestMethod]
        public void EF_GetList()
        {
            var context = new EF();
            var result = context.WeiBos;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Local.Count > 0);

        }
    }
}
