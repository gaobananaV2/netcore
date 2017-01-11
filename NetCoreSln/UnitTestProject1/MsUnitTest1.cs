using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MsUnitTest1
    {
        [TestMethod,TestCategory("a")]
        public void TestMethod1()
        {
        }

        [TestMethod, TestCategory("a")]
        public void TestMethod2()
        {
        }

        [TestMethod, TestCategory("b")]
        public void TestMethod3()
        { 
        }
    }
}
