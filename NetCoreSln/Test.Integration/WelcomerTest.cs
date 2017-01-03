using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Integration
{
    [TestClass]
    public class WelcomerTest
    {
        [TestMethod]
        public void Should_Say_Hello_World()
        {
            Assert.AreEqual("Hello World", Welcomer.SayHello());
        }
    }

    internal class Welcomer
    {
        internal static string SayHello()
        {
            //return string.Empty;
            return "Hello World";
        }
    }
}
