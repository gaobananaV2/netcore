using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace ParallelismConcurrencyUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        #region Properties
        StringBuilder result = new StringBuilder();
        #endregion

        [TestMethod]
        public void TestSerial()
        {

        }


        [TestMethod]
        public void TestParallel()
        {

        }


        [TestMethod]
        public void TestConcurrency()
        {

        }

        private  void ShowResult(string msg)
        {
            File.WriteAllText("TestResult.txt", msg);
        }
    }
}
